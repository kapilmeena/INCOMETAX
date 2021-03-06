﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INCOMETAX.DbModel
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="INCOMETAX")]
	public partial class DataBaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertFILE_DETAIL(FILE_DETAIL instance);
    partial void UpdateFILE_DETAIL(FILE_DETAIL instance);
    partial void DeleteFILE_DETAIL(FILE_DETAIL instance);
    partial void InsertUSER(USER instance);
    partial void UpdateUSER(USER instance);
    partial void DeleteUSER(USER instance);
    partial void InsertMESSAGE_DETAIL(MESSAGE_DETAIL instance);
    partial void UpdateMESSAGE_DETAIL(MESSAGE_DETAIL instance);
    partial void DeleteMESSAGE_DETAIL(MESSAGE_DETAIL instance);
    #endregion
		
		public DataBaseDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["INCOMETAXConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<FILE_DETAIL> FILE_DETAILs
		{
			get
			{
				return this.GetTable<FILE_DETAIL>();
			}
		}
		
		public System.Data.Linq.Table<USER> USERs
		{
			get
			{
				return this.GetTable<USER>();
			}
		}
		
		public System.Data.Linq.Table<MESSAGE_DETAIL> MESSAGE_DETAILs
		{
			get
			{
				return this.GetTable<MESSAGE_DETAIL>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FILE_DETAILS")]
	public partial class FILE_DETAIL : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _FILE_ID;
		
		private string _FILE_NAME;
		
		private System.Nullable<System.DateTime> _CREATED_DATE;
		
		private System.Nullable<int> _ASSIGN_STAFF_ID;
		
		private System.Nullable<System.DateTime> _ASSIGN_DATE;
		
		private System.Nullable<bool> _IS_ASSIGN;
		
		private System.Nullable<int> _COMPLETE_IN_DAYS;
		
		private System.Nullable<System.DateTime> _DEADLINE_DATE;
		
		private System.Nullable<bool> _IS_PENDING;
		
		private System.Nullable<bool> _IS_COMPLETED;
		
		private System.Nullable<int> _CREATED_BY;
		
		private System.Nullable<bool> _IS_DELETE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFILE_IDChanging(int value);
    partial void OnFILE_IDChanged();
    partial void OnFILE_NAMEChanging(string value);
    partial void OnFILE_NAMEChanged();
    partial void OnCREATED_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnCREATED_DATEChanged();
    partial void OnASSIGN_STAFF_IDChanging(System.Nullable<int> value);
    partial void OnASSIGN_STAFF_IDChanged();
    partial void OnASSIGN_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnASSIGN_DATEChanged();
    partial void OnIS_ASSIGNChanging(System.Nullable<bool> value);
    partial void OnIS_ASSIGNChanged();
    partial void OnCOMPLETE_IN_DAYSChanging(System.Nullable<int> value);
    partial void OnCOMPLETE_IN_DAYSChanged();
    partial void OnDEADLINE_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnDEADLINE_DATEChanged();
    partial void OnIS_PENDINGChanging(System.Nullable<bool> value);
    partial void OnIS_PENDINGChanged();
    partial void OnIS_COMPLETEDChanging(System.Nullable<bool> value);
    partial void OnIS_COMPLETEDChanged();
    partial void OnCREATED_BYChanging(System.Nullable<int> value);
    partial void OnCREATED_BYChanged();
    partial void OnIS_DELETEChanging(System.Nullable<bool> value);
    partial void OnIS_DELETEChanged();
    #endregion
		
		public FILE_DETAIL()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FILE_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int FILE_ID
		{
			get
			{
				return this._FILE_ID;
			}
			set
			{
				if ((this._FILE_ID != value))
				{
					this.OnFILE_IDChanging(value);
					this.SendPropertyChanging();
					this._FILE_ID = value;
					this.SendPropertyChanged("FILE_ID");
					this.OnFILE_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FILE_NAME", DbType="VarChar(100)")]
		public string FILE_NAME
		{
			get
			{
				return this._FILE_NAME;
			}
			set
			{
				if ((this._FILE_NAME != value))
				{
					this.OnFILE_NAMEChanging(value);
					this.SendPropertyChanging();
					this._FILE_NAME = value;
					this.SendPropertyChanged("FILE_NAME");
					this.OnFILE_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATED_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATED_DATE
		{
			get
			{
				return this._CREATED_DATE;
			}
			set
			{
				if ((this._CREATED_DATE != value))
				{
					this.OnCREATED_DATEChanging(value);
					this.SendPropertyChanging();
					this._CREATED_DATE = value;
					this.SendPropertyChanged("CREATED_DATE");
					this.OnCREATED_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ASSIGN_STAFF_ID", DbType="Int")]
		public System.Nullable<int> ASSIGN_STAFF_ID
		{
			get
			{
				return this._ASSIGN_STAFF_ID;
			}
			set
			{
				if ((this._ASSIGN_STAFF_ID != value))
				{
					this.OnASSIGN_STAFF_IDChanging(value);
					this.SendPropertyChanging();
					this._ASSIGN_STAFF_ID = value;
					this.SendPropertyChanged("ASSIGN_STAFF_ID");
					this.OnASSIGN_STAFF_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ASSIGN_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> ASSIGN_DATE
		{
			get
			{
				return this._ASSIGN_DATE;
			}
			set
			{
				if ((this._ASSIGN_DATE != value))
				{
					this.OnASSIGN_DATEChanging(value);
					this.SendPropertyChanging();
					this._ASSIGN_DATE = value;
					this.SendPropertyChanged("ASSIGN_DATE");
					this.OnASSIGN_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IS_ASSIGN", DbType="Bit")]
		public System.Nullable<bool> IS_ASSIGN
		{
			get
			{
				return this._IS_ASSIGN;
			}
			set
			{
				if ((this._IS_ASSIGN != value))
				{
					this.OnIS_ASSIGNChanging(value);
					this.SendPropertyChanging();
					this._IS_ASSIGN = value;
					this.SendPropertyChanged("IS_ASSIGN");
					this.OnIS_ASSIGNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COMPLETE_IN_DAYS", DbType="Int")]
		public System.Nullable<int> COMPLETE_IN_DAYS
		{
			get
			{
				return this._COMPLETE_IN_DAYS;
			}
			set
			{
				if ((this._COMPLETE_IN_DAYS != value))
				{
					this.OnCOMPLETE_IN_DAYSChanging(value);
					this.SendPropertyChanging();
					this._COMPLETE_IN_DAYS = value;
					this.SendPropertyChanged("COMPLETE_IN_DAYS");
					this.OnCOMPLETE_IN_DAYSChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DEADLINE_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> DEADLINE_DATE
		{
			get
			{
				return this._DEADLINE_DATE;
			}
			set
			{
				if ((this._DEADLINE_DATE != value))
				{
					this.OnDEADLINE_DATEChanging(value);
					this.SendPropertyChanging();
					this._DEADLINE_DATE = value;
					this.SendPropertyChanged("DEADLINE_DATE");
					this.OnDEADLINE_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IS_PENDING", DbType="Bit")]
		public System.Nullable<bool> IS_PENDING
		{
			get
			{
				return this._IS_PENDING;
			}
			set
			{
				if ((this._IS_PENDING != value))
				{
					this.OnIS_PENDINGChanging(value);
					this.SendPropertyChanging();
					this._IS_PENDING = value;
					this.SendPropertyChanged("IS_PENDING");
					this.OnIS_PENDINGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IS_COMPLETED", DbType="Bit")]
		public System.Nullable<bool> IS_COMPLETED
		{
			get
			{
				return this._IS_COMPLETED;
			}
			set
			{
				if ((this._IS_COMPLETED != value))
				{
					this.OnIS_COMPLETEDChanging(value);
					this.SendPropertyChanging();
					this._IS_COMPLETED = value;
					this.SendPropertyChanged("IS_COMPLETED");
					this.OnIS_COMPLETEDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATED_BY", DbType="Int")]
		public System.Nullable<int> CREATED_BY
		{
			get
			{
				return this._CREATED_BY;
			}
			set
			{
				if ((this._CREATED_BY != value))
				{
					this.OnCREATED_BYChanging(value);
					this.SendPropertyChanging();
					this._CREATED_BY = value;
					this.SendPropertyChanged("CREATED_BY");
					this.OnCREATED_BYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IS_DELETE", DbType="Bit")]
		public System.Nullable<bool> IS_DELETE
		{
			get
			{
				return this._IS_DELETE;
			}
			set
			{
				if ((this._IS_DELETE != value))
				{
					this.OnIS_DELETEChanging(value);
					this.SendPropertyChanging();
					this._IS_DELETE = value;
					this.SendPropertyChanged("IS_DELETE");
					this.OnIS_DELETEChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[USER]")]
	public partial class USER : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _RollId;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _Email;
		
		private string _UserName;
		
		private string _Password;
		
		private string _MobileNo;
		
		private string _Address;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnRollIdChanging(int value);
    partial void OnRollIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnMobileNoChanging(string value);
    partial void OnMobileNoChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    #endregion
		
		public USER()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RollId", DbType="Int NOT NULL")]
		public int RollId
		{
			get
			{
				return this._RollId;
			}
			set
			{
				if ((this._RollId != value))
				{
					this.OnRollIdChanging(value);
					this.SendPropertyChanging();
					this._RollId = value;
					this.SendPropertyChanged("RollId");
					this.OnRollIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(50)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(50)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(500)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MobileNo", DbType="VarChar(50)")]
		public string MobileNo
		{
			get
			{
				return this._MobileNo;
			}
			set
			{
				if ((this._MobileNo != value))
				{
					this.OnMobileNoChanging(value);
					this.SendPropertyChanging();
					this._MobileNo = value;
					this.SendPropertyChanged("MobileNo");
					this.OnMobileNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(100)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MESSAGE_DETAILS")]
	public partial class MESSAGE_DETAIL : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MID;
		
		private string _TEXT;
		
		private System.Nullable<int> _SENDERID;
		
		private System.Nullable<int> _RECIVERID;
		
		private System.Nullable<System.DateTime> _CREATEDDATE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMIDChanging(int value);
    partial void OnMIDChanged();
    partial void OnTEXTChanging(string value);
    partial void OnTEXTChanged();
    partial void OnSENDERIDChanging(System.Nullable<int> value);
    partial void OnSENDERIDChanged();
    partial void OnRECIVERIDChanging(System.Nullable<int> value);
    partial void OnRECIVERIDChanged();
    partial void OnCREATEDDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnCREATEDDATEChanged();
    #endregion
		
		public MESSAGE_DETAIL()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MID
		{
			get
			{
				return this._MID;
			}
			set
			{
				if ((this._MID != value))
				{
					this.OnMIDChanging(value);
					this.SendPropertyChanging();
					this._MID = value;
					this.SendPropertyChanged("MID");
					this.OnMIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEXT", DbType="VarChar(100)")]
		public string TEXT
		{
			get
			{
				return this._TEXT;
			}
			set
			{
				if ((this._TEXT != value))
				{
					this.OnTEXTChanging(value);
					this.SendPropertyChanging();
					this._TEXT = value;
					this.SendPropertyChanged("TEXT");
					this.OnTEXTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SENDERID", DbType="Int")]
		public System.Nullable<int> SENDERID
		{
			get
			{
				return this._SENDERID;
			}
			set
			{
				if ((this._SENDERID != value))
				{
					this.OnSENDERIDChanging(value);
					this.SendPropertyChanging();
					this._SENDERID = value;
					this.SendPropertyChanged("SENDERID");
					this.OnSENDERIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RECIVERID", DbType="Int")]
		public System.Nullable<int> RECIVERID
		{
			get
			{
				return this._RECIVERID;
			}
			set
			{
				if ((this._RECIVERID != value))
				{
					this.OnRECIVERIDChanging(value);
					this.SendPropertyChanging();
					this._RECIVERID = value;
					this.SendPropertyChanged("RECIVERID");
					this.OnRECIVERIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDDATE
		{
			get
			{
				return this._CREATEDDATE;
			}
			set
			{
				if ((this._CREATEDDATE != value))
				{
					this.OnCREATEDDATEChanging(value);
					this.SendPropertyChanging();
					this._CREATEDDATE = value;
					this.SendPropertyChanged("CREATEDDATE");
					this.OnCREATEDDATEChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
