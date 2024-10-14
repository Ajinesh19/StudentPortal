using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StudentPortal.Helper
{
    public class CustomEmailTagHelper:TagHelper
    {
        public string MyEmail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
           output.Attributes.Add("Id","my-email-id");
            output.Content.SetContent("my-email");
        }

    }
}
