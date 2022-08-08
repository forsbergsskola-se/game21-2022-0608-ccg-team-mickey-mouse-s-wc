using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Newtonsoft.Json;
using UnityEngine;
[Serializable][TypeConverter(typeof(StringGuidConverter))][JsonObject]
public class StringGUID{
   [NonSerialized] Guid guid;
   public string GUIDAsString{
      get => guid.ToString();
      set => guid = new Guid(value);
   }
   public StringGUID(string stringGuid){
      var guid = new Guid();
      var guidString = guid.ToString().ToCharArray();
      for (int i = 0; i < guidString.Length; i++){
         if(guidString[i] == 'O'){
            guidString[i] = stringGuid[i];
         }
      }
      Debug.Log(guidString.ToString()); //TODO: FIX
      GUIDAsString = guidString.ToString();
   }

   public StringGUID(){
      GUIDAsString = "00000000-0000-0000-0000-000000000000";
   }

   public StringGUID NewGuid(){
      var guid = Guid.NewGuid().ToString();
      return new StringGUID(guid) ;
   }

   public StringGUID CreateStringGuid(int value){
      var newGuid = new StringGUID();
      char[] newCharArray = newGuid.GUIDAsString.ToCharArray();
      for (int i = 0; i < value.ToString().Length; i++){
         newCharArray[i] = value.ToString()[i];
      }

      string idk = new string(newCharArray);
      return new StringGUID(idk);
   }

   public override string ToString(){
      return GUIDAsString;
   }
}
[JsonObject]
public class StringGuidConverter : TypeConverter{
   public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
   {
      return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
      
   }
   public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
   {
      return value is string s ? new StringGUID(s) : base.ConvertFrom(context, culture, value);
   }

   public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
   {
      return destinationType == typeof(string) && value is StringGUID stringGuid
         ? stringGuid.ToString()
         : base.ConvertTo(context, culture, value, destinationType);
   }
}
