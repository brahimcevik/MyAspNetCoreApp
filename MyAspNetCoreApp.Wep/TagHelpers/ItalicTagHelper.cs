using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAspNetCoreApp.Wep.TagHelpers

{
    public class ItalicTagHelper : TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PostContent.SetHtmlContent("<i>");
            output.PostContent.SetHtmlContent("</li>");
        }


    }
}
