using CatswordsTab.App.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace CatswordsTab.App
{
    class RegistryService
    {

        public static AssociationModel GetAssoiciationByExtension(string extension)
        {
            string skName = String.Format(".{0}", extension);
            return GetAssociationByResourceName(skName);
        }

        public static AssociationModel GetAssociationByResourceName(string resourceName)
        {
            AssociationModel association = null;

            RegistryKey rk = Registry.ClassesRoot;
            string skName = resourceName;

            try
            {
                using (RegistryKey sk = rk.OpenSubKey(skName))
                {
                    association = new AssociationModel
                    {
                        ResourceName = skName,
                        Default = (string)sk.GetValue(null), // null means default value
                        ContentType = (string)sk.GetValue("Content Type"), // attention: 'Content Type' is correct name in Windows registry
                        PerceivedType = (string)sk.GetValue("PerceivedType")
                    };
                }
            }
            catch (Exception)
            {
                // nothing
            }

            return association;
        }

        public static List<AssociationModel> GetAssoiciationItems()
        {
            List<AssociationModel> associations = new List<AssociationModel>();

            RegistryKey rk = Registry.ClassesRoot;
            foreach (string skName in rk.GetSubKeyNames())
            {
                AssociationModel association = GetAssociationByResourceName(skName);
                if (association != null)
                {
                    associations.Add(association);
                }
            }

            return associations;
        }
    }
}
