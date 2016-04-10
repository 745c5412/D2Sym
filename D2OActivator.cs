﻿using D2Sym.Classes;
using D2Sym.InternalClasses;

using D2Sym.D2O;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using D2Sym.D2I;

namespace D2Sym.D2O
{
    /// <summary>
    /// DOFUS >= 2.29 D2O Reader / DBSynchroniser
    /// </summary>
    public class D2OActivator
    {
        public static D2IFile D2IFile { get; set; }

        static bool Log { get; set; }

        /// <summary>
        /// Charge les fichiers D2O 
        /// </summary>
        /// <param name="d2oDirectory">Dossier ou les D2O sont contenu</param>
        /// <param name="d2iFilePath">Emplacement du fichier d2i</param>
        /// <param name="log">Les informations doivent elle être log dans la console?</param>
        public static void OpenD2Os(string d2oDirectory,string d2iFilePath,bool log)
        {
            Log = log;
            GameData.Init(d2oDirectory);
            D2IFile = new D2IFile();
            try
            {
                D2IFile.Open(d2iFilePath);
                if (log)
                Console.WriteLine("D2I File Loaded");
            }
            catch
            {
                throw new Exception(string.Format("Unable to find D2IFile: {0}", d2iFilePath));
            }
            foreach (var value in Enum.GetValues(typeof(D2oFileEnum)))
            {
                LoadD2OFile((D2oFileEnum)value, Log);
            }
        }
        /// <summary>
        /// Retourne un tableau de string représentant chaques nom de fichier d2o
        /// </summary>
        /// <returns></returns>
        public static string[] GetD2ONames()
        {
            var concerned = Assembly.GetExecutingAssembly().GetTypes().ToList().FindAll(x => HasInterface(x,typeof(ID2OClass)));
            return concerned.ConvertAll<string>(x => x.Name).ToArray();
        }
        public static Type GetD2O(string name)
        {
            return Assembly.GetAssembly(typeof(D2OActivator)).GetTypes().FirstOrDefault(x => x.Name == name);
        }
        static void LoadD2OFile(D2oFileEnum filetype, bool log)
        {
            DataClass[] classes = GameData.GetDataObjects(filetype);
            foreach (var dataclass in classes)
            {
                if (!LoadClass(dataclass))
                    return;
            }
            if (Log)
                Console.WriteLine(classes.First().Name + " Loaded..");

        }
        public static string[] GetD2OFields<T>() where T : ID2OClass
        {
            return D2OSynchroniser.GetD2OFields(typeof(T));
        }
        public static List<T> GetD2OValue<T>(Predicate<T> predicate) where T : ID2OClass
        {
            return GetD2OValues<T>().FindAll(predicate);
        }
        /// <summary>
        /// Retourne le cache d'un D2O
        /// </summary>
        /// <typeparam name="T">Parametre de Type du D2O</typeparam>
        /// <returns>Cache du D2O</returns>
        public static List<T> GetD2OValues<T>() where T : ID2OClass
        {
            var type = typeof(T);
            var cache = GetCache(type);
            return (List<T>)cache.GetValue(null);
        }


       
        static Object GetInternalObject(DataClass dataclass)
        {
            List<object> fieldsValue = new List<object>();
            var type = Type.GetType("D2Sym.InternalClasses." + dataclass.Name + "");
            if (type == null)
                return null;
            foreach (var field in type.GetFields().ToList().FindAll(x => !x.IsStatic))
            {
                var objectField = dataclass.Fields[field.Name];
                var fieldType = field.FieldType;
                var objectConverted = Convert.ChangeType(objectField, fieldType);
                var t = objectConverted.GetType();
                fieldsValue.Add(objectConverted);
            }
            return Activator.CreateInstance(type, fieldsValue.ToArray());
        }
        static bool LoadClass(DataClass data)
        {
            var type = Type.GetType("D2Sym.Classes." + data.Name + "");
            if (type == null) // no .cs class linked to the d2os
            {
                return false;
            }
            List<object> fieldsValue = new List<object>();
            foreach (var field in type.GetFields().ToList().FindAll(x => !x.IsStatic))
            {
                var objectField = data.Fields[field.Name];
                var fieldType = field.FieldType;
                if (objectField.GetType() == typeof(DataClass))
                {
                    var d2oClass = objectField as DataClass;
                    var internalObj = GetInternalObject(d2oClass);
                    if (internalObj != null)
                        fieldsValue.Add(internalObj);
                    else
                        fieldsValue.Add(d2oClass);
                }
                else if (fieldType.IsArray) // si c'est un ArrayList on le convertit en tableau du type correspondant
                {
                    var array = (objectField as ArrayList);
                    var T = Type.GetTypeArray(array.ToArray());
                    if (T.Count() > 0 && T[0] == typeof(DataClass))
                    {

                        List<object> objects = new List<object>();

                        var classes = array.ToArray(T[0]);

                        foreach (DataClass D2oclass in classes)
                        {
                            var internalClass = GetInternalObject(D2oclass);
                            if (internalClass != null)
                                objects.Add(internalClass);
                            else
                                objects.Add(null);
                        }

                        fieldsValue.Add(objects.ToArray());

                    }
                    else
                    {
                        if (T.Count() > 0)
                            fieldsValue.Add(array.ToArray(T[0]));

                        else
                            fieldsValue.Add(Activator.CreateInstance(fieldType, 0));
                    }
                }
                else
                {
                    var objectConverted = Convert.ChangeType(objectField, fieldType);
                    fieldsValue.Add(objectConverted);
                }
            }

            var instance = Activator.CreateInstance(type, fieldsValue.ToArray());
            var cacheField = GetCache(instance.GetType());
            if (cacheField == null)
            {
                if (Log)
                    Console.WriteLine("Unable to add datas to cache, wasent finded");
                return false;
            }
            var method = cacheField.FieldType.GetMethod("Add");
            method.Invoke(cacheField.GetValue(null), new object[] { instance });
            return true;

        }
        public static T GetInternalClass<T>(string serialized) where T : ID2OInternalClass
        {
          
            var internalType = typeof(T);
        
            var internalFields = internalType.GetFields();
            var splited = serialized.Split(D2OSynchroniser.InternalFieldValueDelimitator);
            if (serialized == string.Empty || splited.Length != internalFields.Length)
                return (T)Activator.CreateInstance(internalType, new object[internalFields.Length]);
            object[] fieldsValues = new object[internalType.GetFields().Length];
            int i = 0;

            foreach (var fieldValue in splited)
            {
                Type fieldType = internalFields[i].FieldType;
                fieldsValues[i] = (Convert.ChangeType(fieldValue, fieldType));
                i++;
            }
            return (T)Activator.CreateInstance(internalType, fieldsValues);
        }
        static FieldInfo GetCache(Type d2oType)
        {
            return d2oType.GetFields().FirstOrDefault(x => x.GetCustomAttribute(typeof(CacheAttribute)) != null);
        }
        public static bool HasInterface(this Type type, Type interfaceType)
        {
            return type.FindInterfaces(new TypeFilter(FilterByName), interfaceType).Length > 0;
        }
        private static bool FilterByName(Type typeObj, object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }
    }
}
