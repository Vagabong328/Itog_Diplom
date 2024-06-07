﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cinema_Play
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CinemaPlayBD")]
	public partial class UserLinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertСотрудники(Сотрудники instance);
    partial void UpdateСотрудники(Сотрудники instance);
    partial void DeleteСотрудники(Сотрудники instance);
    #endregion
		
		public UserLinqDataContext() : 
				base(global::Cinema_Play.Properties.Settings.Default.CinemaPlayBDConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public UserLinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserLinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserLinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UserLinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Сотрудники> Сотрудники
		{
			get
			{
				return this.GetTable<Сотрудники>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Сотрудники")]
	public partial class Сотрудники : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Код_сотрудника;
		
		private string _ФИО;
		
		private string _Логин;
		
		private string _Пароль;
		
		private string _Должность;
		
		private string _Телефон;
		
		private string _Почта;
		
		private System.Nullable<System.DateTime> _Дата_трудоустройства;
		
		private string _Оклад;
		
		private string _Адрес;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnКод_сотрудникаChanging(int value);
    partial void OnКод_сотрудникаChanged();
    partial void OnФИОChanging(string value);
    partial void OnФИОChanged();
    partial void OnЛогинChanging(string value);
    partial void OnЛогинChanged();
    partial void OnПарольChanging(string value);
    partial void OnПарольChanged();
    partial void OnДолжностьChanging(string value);
    partial void OnДолжностьChanged();
    partial void OnТелефонChanging(string value);
    partial void OnТелефонChanged();
    partial void OnПочтаChanging(string value);
    partial void OnПочтаChanged();
    partial void OnДата_трудоустройстваChanging(System.Nullable<System.DateTime> value);
    partial void OnДата_трудоустройстваChanged();
    partial void OnОкладChanging(string value);
    partial void OnОкладChanged();
    partial void OnАдресChanging(string value);
    partial void OnАдресChanged();
    #endregion
		
		public Сотрудники()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Код сотрудника]", Storage="_Код_сотрудника", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Код_сотрудника
		{
			get
			{
				return this._Код_сотрудника;
			}
			set
			{
				if ((this._Код_сотрудника != value))
				{
					this.OnКод_сотрудникаChanging(value);
					this.SendPropertyChanging();
					this._Код_сотрудника = value;
					this.SendPropertyChanged("Код_сотрудника");
					this.OnКод_сотрудникаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ФИО", DbType="NVarChar(50)")]
		public string ФИО
		{
			get
			{
				return this._ФИО;
			}
			set
			{
				if ((this._ФИО != value))
				{
					this.OnФИОChanging(value);
					this.SendPropertyChanging();
					this._ФИО = value;
					this.SendPropertyChanged("ФИО");
					this.OnФИОChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Логин", DbType="NVarChar(50)")]
		public string Логин
		{
			get
			{
				return this._Логин;
			}
			set
			{
				if ((this._Логин != value))
				{
					this.OnЛогинChanging(value);
					this.SendPropertyChanging();
					this._Логин = value;
					this.SendPropertyChanged("Логин");
					this.OnЛогинChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Пароль", DbType="NVarChar(50)")]
		public string Пароль
		{
			get
			{
				return this._Пароль;
			}
			set
			{
				if ((this._Пароль != value))
				{
					this.OnПарольChanging(value);
					this.SendPropertyChanging();
					this._Пароль = value;
					this.SendPropertyChanged("Пароль");
					this.OnПарольChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Должность", DbType="NVarChar(50)")]
		public string Должность
		{
			get
			{
				return this._Должность;
			}
			set
			{
				if ((this._Должность != value))
				{
					this.OnДолжностьChanging(value);
					this.SendPropertyChanging();
					this._Должность = value;
					this.SendPropertyChanged("Должность");
					this.OnДолжностьChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Телефон", DbType="NChar(50)")]
		public string Телефон
		{
			get
			{
				return this._Телефон;
			}
			set
			{
				if ((this._Телефон != value))
				{
					this.OnТелефонChanging(value);
					this.SendPropertyChanging();
					this._Телефон = value;
					this.SendPropertyChanged("Телефон");
					this.OnТелефонChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Почта", DbType="NVarChar(50)")]
		public string Почта
		{
			get
			{
				return this._Почта;
			}
			set
			{
				if ((this._Почта != value))
				{
					this.OnПочтаChanging(value);
					this.SendPropertyChanging();
					this._Почта = value;
					this.SendPropertyChanged("Почта");
					this.OnПочтаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Дата трудоустройства]", Storage="_Дата_трудоустройства", DbType="Date")]
		public System.Nullable<System.DateTime> Дата_трудоустройства
		{
			get
			{
				return this._Дата_трудоустройства;
			}
			set
			{
				if ((this._Дата_трудоустройства != value))
				{
					this.OnДата_трудоустройстваChanging(value);
					this.SendPropertyChanging();
					this._Дата_трудоустройства = value;
					this.SendPropertyChanged("Дата_трудоустройства");
					this.OnДата_трудоустройстваChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Оклад", DbType="NChar(50)")]
		public string Оклад
		{
			get
			{
				return this._Оклад;
			}
			set
			{
				if ((this._Оклад != value))
				{
					this.OnОкладChanging(value);
					this.SendPropertyChanging();
					this._Оклад = value;
					this.SendPropertyChanged("Оклад");
					this.OnОкладChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Адрес", DbType="NVarChar(50)")]
		public string Адрес
		{
			get
			{
				return this._Адрес;
			}
			set
			{
				if ((this._Адрес != value))
				{
					this.OnАдресChanging(value);
					this.SendPropertyChanging();
					this._Адрес = value;
					this.SendPropertyChanged("Адрес");
					this.OnАдресChanged();
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
