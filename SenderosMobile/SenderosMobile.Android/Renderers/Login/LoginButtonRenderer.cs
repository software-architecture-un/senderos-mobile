﻿using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using SenderosMobile.Droid;
using Android.Graphics.Drawables;
using Android.Views;
using SenderosMobile;
using SenderosMobileLanguage.Resx;
using Android.Graphics;
using Android.Support.Design.Widget;

[assembly: ExportRenderer(typeof(LoginButton), typeof(LoginButtonRenderer))]
namespace SenderosMobile.Droid
{
    class LoginButtonRenderer : ButtonRenderer
    {
        public LoginButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                GradientDrawable gradientDrawable = new GradientDrawable(); // Para seleccionar los colores y otros atributos utilizados en el Button

                gradientDrawable.SetCornerRadius(50f); // Las esquinas del Entry tendrán radio 50
                gradientDrawable.SetColor(Android.Graphics.Color.Rgb(138, 223, 220)); // Selecciona el color del fondo de Button (#8ADFDC)
                gradientDrawable.SetStroke(2, Android.Graphics.Color.Rgb(124, 124, 124)); // Selecciona el color del borde de Button (#7C7C7C)

                Control.SetBackground(gradientDrawable); // El fondo del Button será del color seleccionado en gradientDrawable

                Control.SetTextColor(Android.Graphics.Color.Rgb(43, 48, 58)); // Selecciona el color del texto de Button activado (#2B303A)

                Control.SetTextSize(Android.Util.ComplexUnitType.Sp, 14); // Tamaño de la letra del Button
                Control.Gravity = GravityFlags.Center; // Alinea al centro el texto que hay dentro del Button

                Control.SetAllCaps(false); // El texto del Button ya no será totalmente en mayúsculas

                /* Fuente */
                Typeface font = Typeface.CreateFromAsset(Context.Assets, "Poppins-SemiBold.ttf");
                Control.Typeface = font;

                //Control.PaintFlags = PaintFlags.UnderlineText; // Texto del Button subrayado
            }
        }
    }
}