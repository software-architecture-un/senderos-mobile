﻿using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using SenderosMobile.Droid;
using Android.Graphics.Drawables;
using Android.Views;
using SenderosMobile;
using Android.Graphics;

[assembly: ExportRenderer(typeof(PasswordEntry), typeof(PasswordEntryRenderer))]
namespace SenderosMobile.Droid
{
    class PasswordEntryRenderer : EntryRenderer
    {
        public PasswordEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                GradientDrawable gradientDrawable = new GradientDrawable(); // Para seleccionar los colores y otros atributos utilizados en el Entry

                gradientDrawable.SetCornerRadius(50f); // Las esquinas del Entry tendrán radio 50
                gradientDrawable.SetColor(Android.Graphics.Color.White); // Selecciona el color de fondo del Entry
                gradientDrawable.SetStroke(2, Android.Graphics.Color.Rgb(124, 124, 124)); // Selecciona el color del borde de Entry (#7C7C7C)

                Control.SetBackground(gradientDrawable); // El fondo del Entry será del color seleccionado en gradientDrawable
                Control.SetTextColor(Android.Graphics.Color.Black); // Selecciona el color del texto de Entry activado

                Control.SetTextSize(Android.Util.ComplexUnitType.Sp, 16); // Tamaño de la letra del Entry
                Control.Gravity = GravityFlags.Center; // Alinea a la izquierda el texto que hay dentro del Entry

                /* Fuente */
                Typeface font = Typeface.CreateFromAsset(Context.Assets, "Poppins-SemiBold.ttf");
                Control.Typeface = font;

                //Control.PaintFlags = PaintFlags.UnderlineText; // Texto del Entry subrayado
            }
        }
    }
}