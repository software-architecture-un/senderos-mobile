﻿using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using SenderosMobile.Droid;
using Android.Graphics.Drawables;
using Android.Views;
using SenderosMobile;
using SenderosMobileLanguage.Resx;
using Android.Graphics;

[assembly: ExportRenderer(typeof(TitleLabel), typeof(TitleLabelRenderer))]
namespace SenderosMobile.Droid
{
    class TitleLabelRenderer : LabelRenderer
    {
        public TitleLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                GradientDrawable gradientDrawable = new GradientDrawable(); // Para seleccionar los colores y otros atributos utilizados en el Label

                gradientDrawable.SetColor(Android.Graphics.Color.Transparent); // Selecciona el color de fondo del Entry
                gradientDrawable.SetStroke(2, Android.Graphics.Color.Transparent); // Selecciona el color del borde de Entry

                Control.SetBackground(gradientDrawable); // El fondo del Entry será del color seleccionado en gradientDrawable

                Control.SetTextColor(Android.Graphics.Color.Rgb(214, 73, 51)); // Selecciona el color del texto de Entry activado (#D64933)

                Control.SetTextSize(Android.Util.ComplexUnitType.Sp, 50); // Tamaño de la letra del Entry
                Control.Gravity = GravityFlags.Center; // Alinea al centro el texto que hay dentro del Entry


                /* Fuente */
                Typeface font = Typeface.CreateFromAsset(Context.Assets, "Poppins-Bold.ttf");
                Control.Typeface = font;

                //Control.SetAllCaps(false); // El texto del Entry ya no será totalmente en mayúsculas

                //Control.PaintFlags = PaintFlags.UnderlineText; // Texto del Button subrayado
            }
        }
    }
}