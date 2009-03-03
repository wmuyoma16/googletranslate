// MainWindow.cs created with MonoDevelop
// User: dark_ai at 10:06 02.03.2009
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using Gtk;
using GoogleTranslate;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnBChangeClicked (object sender, System.EventArgs e)
	{
		int t = CB_first.Active;
		CB_first.Active = CB_second.Active;
		CB_second.Active = t;
	}

	protected virtual void OnBTranslateClicked (object sender, System.EventArgs e)
	{
		if (TTV_first.Buffer.Text != "")
		{
			TTV_second.Buffer = new TextBuffer(new TextTagTable());
		    GWords words = GTranslate.Translate(CB_first.ActiveText,CB_second.ActiveText,TTV_first.Buffer.Text);
		    TTV_second.Buffer.Text = words.Translate;
		}
	}

	protected virtual void OnMapped (object sender, System.EventArgs e)
	{
	
	}
}




		