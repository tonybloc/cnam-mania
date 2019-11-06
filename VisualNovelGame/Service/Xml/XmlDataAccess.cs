using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace cnam_mania.VisualNovelGame.Service.Xml
{
    public static class XmlDataAccess
    {
        /// <summary>
        /// Deserialize an object
        /// </summary>
        /// <typeparam name="T">Object's type</typeparam>
        /// <param name="pFilePath">Path of the XML file</param>
        /// <returns>An object</returns>
        public static T XMLDeserializeObject<T>(string pFilePath)
        {
            T myObject = default(T);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlReaderSettings settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
                using (StreamReader streamReader = new StreamReader(pFilePath))
                {
                    using (XmlReader xmlReader = XmlReader.Create(streamReader, settings))
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                using (XmlReader subReader = xmlReader.ReadSubtree())
                                {
                                    myObject = (T)serializer.Deserialize(subReader);
                                }
                            }
                        }
                    }
                }
            }
            
            catch (InvalidOperationException expOperation)
            {
                Console.WriteLine(string.Format("Erreur dans le fichier xml : {0}", expOperation.Message));
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            Console.WriteLine("\n========== Désérialisation effectuée avec succès ! ==========\n");
            return myObject;
        }

        /// <summary>
        /// Deserialize a list of objects
        /// </summary>
        /// <typeparam name="T">Object's type</typeparam>
        /// <param name="pFilePath">Path of the XML file</param>
        /// <returns>List of objects</returns>
        public static List<T> XMLDeserializeListOf<T>(string pFilePath)
        {
            List<T> ListOfObjects = new List<T>();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlReaderSettings settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
                using (StreamReader streamReader = new StreamReader(pFilePath))
                {
                    using (XmlReader xmlReader = XmlReader.Create(streamReader, settings))
                    {
                        while(xmlReader.Read())
                        {
                            if(xmlReader.NodeType == XmlNodeType.Element)
                            {
                                using (XmlReader subReader = xmlReader.ReadSubtree())
                                {
                                    T myObject = (T)serializer.Deserialize(subReader);
                                    ListOfObjects.Add(myObject);
                                }
                            }
                        }
                    }
                }
            }
            catch(InvalidOperationException expOperation)
            {
                Console.WriteLine(string.Format("Erreur dans le fichier xml : {0}", expOperation.Message));
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }


            return ListOfObjects;
        }
    }
}
