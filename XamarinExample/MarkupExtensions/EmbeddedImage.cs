using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinExample.MarkupExtensions
{
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string ResouceId { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResouceId))
                return null;

            return ImageSource.FromResource(ResouceId);
        }
    }
}