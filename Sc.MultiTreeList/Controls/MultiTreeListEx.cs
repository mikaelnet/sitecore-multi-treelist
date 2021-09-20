using JetBrains.Annotations;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Text;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;

namespace Sc.MultiTreeList.Controls
{
    public class MultiTreeListEx : Sitecore.Shell.Applications.ContentEditor.FieldTypes.TreelistEx
    {
        // Overridden to launch our custom MultiTreeListExEditor instead of the normal one
        [UsedImplicitly]
        protected new void Edit(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, nameof (args));
            if (Disabled)
                return;

            if (args.IsPostBack)
            {
                // Let the base method handle this since there are no changes
                // (and it calls a private method, so we cannot copy/paste it here)
                base.Edit(args);
            }
            else
            {
                #region MultiTreeList Adaptation

                // Use a MultiTreeListExEditor instead of the default
                UrlString urlString = new UrlString(UIUtil.GetUri("control:MultiTreeListExEditor"));

                #endregion

                urlString.Parameters.Add("filterItem", this.Source);
                UrlHandle urlHandle = new UrlHandle();
                string empty = this.Value;
                if (empty == "__#!$No value$!#__")
                    empty = string.Empty;
                urlHandle["value"] = empty;
                urlHandle["source"] = Source;
                urlHandle["language"] = ItemLanguage;
                urlHandle["itemID"] = ItemID;
                urlHandle.Add(urlString);
                urlString.Append("sc_content", WebUtil.GetQueryString("sc_content"));
                SheerResponse.ShowModalDialog(urlString.ToString(), "1200px", "700px", string.Empty, true);
                args.WaitForPostBack();
            }
        }

    }
}