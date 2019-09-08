using CatswordsTab.WebApi.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace CatswordsTab.WebApi
{
    public class RegistryService
    {
        public static AssociationModel GetAssoiciationByExtension(string extension)
        {
            if (extension.Length > 0)
            {
                string skName;

                if(extension.Substring(0, 1).Equals(".")) {
                    skName = extension;
                }
                else
                {
                    skName = string.Format(".{0}", extension);
                }

                skName = skName.ToLower();
                return GetAssociationByResourceName(skName);
            }
            else
            {
                return null;
            }
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

        public static List<AssociationModel> GetAssoiciations()
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
        public static List<ApplianceModel> GetInstalledApps()
        {
            List<ApplianceModel> items = new List<ApplianceModel>();

            List<RegistryKey> regKeys = new List<RegistryKey>
            {
                Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"),
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"),
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall")
            };

            foreach (RegistryKey rk in regKeys)
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            items.Add(new ApplianceModel
                            {
                                ResourceName = (string)sk.GetValue("ResourceName"),
                                Default = (string)sk.GetValue(null),
                                InstallDate = (string)sk.GetValue("InstallDate"),
                                InstallLocation = (string)sk.GetValue("InstallLocation"),
                                Publisher = (string)sk.GetValue("Publisher"),
                                DisplayIcon = (string)sk.GetValue("DisplayIcon"),
                                DisplayName = (string)sk.GetValue("DisplayName"),
                                DisplayVersion = (string)sk.GetValue("DisplayVersion"),
                                HelpLink = (string)sk.GetValue("HelpLink"),
                                UninstallString = (string)sk.GetValue("UninstallString")
                            });
                        }
                        catch (Exception)
                        {
                            // nothing
                        }
                    }
                }
            }

            return items;
        }

        public static string GetValueByKeyName_HKLM(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public static string GetOSVersion()
        {
            string ProductName = GetValueByKeyName_HKLM(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = GetValueByKeyName_HKLM(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }
    }
}