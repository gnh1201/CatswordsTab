using CatswordsTab.App.Model;
using Microsoft.Win32;
using System;

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
                        ContentType = (string)sk.GetValue("Content Type"), // attention: 'Content Type' correct in windows registry
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
    }
}
