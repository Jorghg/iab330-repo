package md55bb7c99105548f62e07fc1e4645373af;


public class ContactUsView
	extends md5c293e307133ee8f46151deed2480c6a8.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("iRecover.Droid.Views.ContactUsView, iRecover.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ContactUsView.class, __md_methods);
	}


	public ContactUsView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ContactUsView.class)
			mono.android.TypeManager.Activate ("iRecover.Droid.Views.ContactUsView, iRecover.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
