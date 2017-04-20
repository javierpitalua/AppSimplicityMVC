using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;

namespace AppSimplicity.MVC.Navigation
{
    public class DefaultMenuLoader : IMenuLoader
    {
        /// <summary>
        /// This method must be overriden to test if a menuitem should be included in the menu option.  Also, menu item can be altered for custom functionality.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>If node should be skipped, then returns false</returns>
        public virtual bool FixNode(ref MenuItem item, string currentPath)
        {
            return true;
        }

        public NavigationModel LoadNavigationModel(string culture, string currentPath)
        {
            string inputFile;
            NavigationModel model = new NavigationModel();

            MenuItem ParentLevel;
            MenuItem ChildLevel;

            //Fix culture file:
            inputFile = System.Web.HttpContext.Current.Server.MapPath(string.Format(Properties.Settings.Default.SitemapLocation, culture));

            if (System.IO.File.Exists(inputFile))
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(inputFile);

                foreach (DataRow drFirstLevel in ds.Tables["Option"].Rows)
                {
                    ParentLevel = new MenuItem()
                    {
                        Title = drFirstLevel["title"].ToString(),
                        Icon = drFirstLevel["icon"].ToString(),
                        URL = drFirstLevel["url"].ToString(),
                        Target = drFirstLevel["target"].ToString(),
                        Roles = drFirstLevel["roles"].ToString(),
                        Class = drFirstLevel["class"].ToString()
                    };

                    //Fix url in each case:
                    if (ParentLevel.URL.StartsWith("~"))
                    {
                        ParentLevel.URL = VirtualPathUtility.ToAbsolute(ParentLevel.URL);
                    }

                    if (string.IsNullOrEmpty(ParentLevel.Roles))
                    {
                        // TODO: implement custom role providers.
                    }

                    foreach (DataRow drSecondLevel in ds.Tables["Node"].Select(string.Format("Option_Id = {0}", drFirstLevel["Option_Id"])))
                    {
                        ChildLevel = new MenuItem()
                        {
                            Title = drSecondLevel["title"].ToString(),
                            Icon = drSecondLevel["icon"].ToString(),
                            URL = drSecondLevel["url"].ToString(),
                            Target = drSecondLevel["target"].ToString(),
                            Roles = drSecondLevel["roles"].ToString()
                        };

                        //Fix url in each case:
                        if (ChildLevel.URL.StartsWith("~"))
                        {
                            ChildLevel.URL = VirtualPathUtility.ToAbsolute(ChildLevel.URL);
                        }

                        if (FixNode(ref ChildLevel, currentPath))
                        {
                            ParentLevel.MenuItems.Add(ChildLevel);
                            string fixedPath = currentPath.StartsWith("~") ? VirtualPathUtility.ToAbsolute(currentPath) : currentPath;
                            if (ChildLevel.URL.ToLower() == fixedPath.ToLower())
                            {
                                ChildLevel.Selected = true;
                                ParentLevel.Selected = true;
                            }
                        }
                    }

                    if (FixNode(ref ParentLevel, currentPath))
                    {
                        if (!ParentLevel.Selected)
                        {
                            string fixedPath = currentPath.StartsWith("~") ? VirtualPathUtility.ToAbsolute(currentPath) : currentPath;
                            if (ParentLevel.URL.ToLower() == fixedPath.ToLower())
                            {
                                ParentLevel.Selected = true;
                            }
                        }

                        model.MenuItems.Add(ParentLevel);
                    }
                }
            }
            else
            {
                throw new Exception(string.Format(Messages.SITEMAP_ASSET_FILE_NOTEXISTS, inputFile));
            }

            return model;
        }
    }
}
