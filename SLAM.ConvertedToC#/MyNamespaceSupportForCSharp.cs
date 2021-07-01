using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

// This file was created by the VB to C# converter (SharpDevelop 4.4.2.9749).
// It contains classes for supporting the VB "My" namespace in C#.
// If the VB application does not use the "My" namespace, or if you removed the usage
// after the conversion to C#, you can delete this file.

namespace SLAM.My
{
	sealed partial class MyProject
	{
		[ThreadStatic] static MyApplication application;
		
		public static MyApplication Application {
			[DebuggerStepThrough]
			get {
				if (application == null)
					application = new MyApplication();
				return application;
			}
		}
		
		[ThreadStatic] static MyComputer computer;
		
		public static MyComputer Computer {
			[DebuggerStepThrough]
			get {
				if (computer == null)
					computer = new MyComputer();
				return computer;
			}
		}
		
		[ThreadStatic] static User user;
		
		public static User User {
			[DebuggerStepThrough]
			get {
				if (user == null)
					user = new User();
				return user;
			}
		}
		
		[ThreadStatic] static MyForms forms;
		
		public static MyForms Forms {
			[DebuggerStepThrough]
			get {
				if (forms == null)
					forms = new MyForms();
				return forms;
			}
		}
		
		internal sealed class MyForms
		{
			global::SLAM.SelectKey SelectKey_instance;
			bool SelectKey_isCreating;
			public global::SLAM.SelectKey SelectKey {
				[DebuggerStepThrough] get { return GetForm(ref SelectKey_instance, ref SelectKey_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref SelectKey_instance, value); }
			}
			
			global::SLAM.SettingsForm SettingsForm_instance;
			bool SettingsForm_isCreating;
			public global::SLAM.SettingsForm SettingsForm {
				[DebuggerStepThrough] get { return GetForm(ref SettingsForm_instance, ref SettingsForm_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref SettingsForm_instance, value); }
			}
			
			global::SLAM.Form1 Form1_instance;
			bool Form1_isCreating;
			public global::SLAM.Form1 Form1 {
				[DebuggerStepThrough] get { return GetForm(ref Form1_instance, ref Form1_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref Form1_instance, value); }
			}
			
			global::SLAM.SetVolume SetVolume_instance;
			bool SetVolume_isCreating;
			public global::SLAM.SetVolume SetVolume {
				[DebuggerStepThrough] get { return GetForm(ref SetVolume_instance, ref SetVolume_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref SetVolume_instance, value); }
			}
			
			global::SLAM.TrimForm TrimForm_instance;
			bool TrimForm_isCreating;
			public global::SLAM.TrimForm TrimForm {
				[DebuggerStepThrough] get { return GetForm(ref TrimForm_instance, ref TrimForm_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref TrimForm_instance, value); }
			}
			
			global::SLAM.RenameForm RenameForm_instance;
			bool RenameForm_isCreating;
			public global::SLAM.RenameForm RenameForm {
				[DebuggerStepThrough] get { return GetForm(ref RenameForm_instance, ref RenameForm_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref RenameForm_instance, value); }
			}
			
			[DebuggerStepThrough]
			static T GetForm<T>(ref T instance, ref bool isCreating) where T : Form, new()
			{
				if (instance == null || instance.IsDisposed) {
					if (isCreating) {
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
					}
					isCreating = true;
					try {
						instance = new T();
					} catch (System.Reflection.TargetInvocationException ex) {
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[] { ex.InnerException.Message }), ex.InnerException);
					} finally {
						isCreating = false;
					}
				}
				return instance;
			}
			
			[DebuggerStepThrough]
			static void SetForm<T>(ref T instance, T value) where T : Form
			{
				if (instance != value) {
					if (value == null) {
						instance.Dispose();
						instance = null;
					} else {
						throw new ArgumentException("Property can only be set to null");
					}
				}
			}
		}
	}
	
	partial class MyApplication : WindowsFormsApplicationBase
	{
		[STAThread]
		public static void Main(string[] args)
		{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
	}
	
	partial class MyComputer : Computer
	{
	}
}
