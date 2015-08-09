using ItemGen.Sitecore.Data.Schemas;
using ItemGen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemGen.Sitecore.GenTools
{
    /// <summary>
    /// UNDER CONSTRUCTION
    /// </summary>
    public class TemplateGenTool : IGenTool<Template, string>
    {
        public string Apply(Template item)
        {
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                //Set the master database we will be working with.
                Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");

                string fullPath = item.Path + item.Name;

                //Look for the template on the database, if not found a null value will be set
                Sitecore.Data.Items.TemplateItem templateItem = master.Templates[fullPath];
                
                //Check if template Item does not exists              
                if (templateItem == null)
                {
                    //Get the parent Item of the template (folder)
                    Sitecore.Data.Items.Item parentItem  = master.Items.GetItem(item.Path);

                    //Create the template under the given parent Item
                    templateItem = master.Templates.CreateTemplate(fullPath, parentItem);
                }               

            }
        }
    }
}
