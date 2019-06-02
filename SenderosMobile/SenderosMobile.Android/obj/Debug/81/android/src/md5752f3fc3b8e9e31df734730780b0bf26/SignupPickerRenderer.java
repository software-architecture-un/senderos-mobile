package md5752f3fc3b8e9e31df734730780b0bf26;


public class SignupPickerRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.PickerRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SenderosMobile.Droid.SignupPickerRenderer, SenderosMobile.Android", SignupPickerRenderer.class, __md_methods);
	}


	public SignupPickerRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SignupPickerRenderer.class)
			mono.android.TypeManager.Activate ("SenderosMobile.Droid.SignupPickerRenderer, SenderosMobile.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SignupPickerRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SignupPickerRenderer.class)
			mono.android.TypeManager.Activate ("SenderosMobile.Droid.SignupPickerRenderer, SenderosMobile.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SignupPickerRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SignupPickerRenderer.class)
			mono.android.TypeManager.Activate ("SenderosMobile.Droid.SignupPickerRenderer, SenderosMobile.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
