// Type: EPiServer.Data.Dynamic.InlinePropertyMap
// Assembly: EPiServer.Data, Version=6.2.267.1, Culture=neutral, PublicKeyToken=8fe83dea738b45b7
// Assembly location: C:\Projects\opensource\Geta.DdsAdmin\packages\EPiServer.Framework.6.2.267.1\lib\EPiServer.Data.dll

using EPiServer.Data.Dynamic.Providers;
using System;

namespace EPiServer.Data.Dynamic
{
  public class InlinePropertyMap : PropertyMap
  {
    private ColumnInformation _columnInformation;

    internal string ColumnName { get; set; }

    internal string TableName { get; set; }

    public ColumnInformation ColumnInfo
    {
      get
      {
        if (this._columnInformation == null)
          this._columnInformation = TableInformation.Get(this.TableName).GetColumn(this.ColumnName, false);
        return this._columnInformation;
      }
    }

    public int RowIndex { get; internal set; }

    public InlinePropertyMap(string propertyName, Type propertyType, int version, string columnName, string tableName, int rowIndex)
      : base(propertyName, propertyType, PropertyMapType.Inline, version)
    {
      this.ColumnName = columnName;
      this.TableName = tableName;
      this.RowIndex = rowIndex;
    }

    protected InlinePropertyMap(InlinePropertyMap other)
      : base((PropertyMap) other)
    {
      this.ColumnName = other.ColumnName;
      this.TableName = other.TableName;
      this.RowIndex = other.RowIndex;
    }

    public override bool Equals(object obj)
    {
      InlinePropertyMap inlinePropertyMap = obj as InlinePropertyMap;
      if (inlinePropertyMap == null || !base.Equals(obj) || (!(this.ColumnName == inlinePropertyMap.ColumnName) || !(this.TableName == inlinePropertyMap.TableName)))
        return false;
      else
        return this.RowIndex == inlinePropertyMap.RowIndex;
    }

    public override int GetHashCode()
    {
      int hashCode = base.GetHashCode();
      if (this.ColumnName != null)
        hashCode ^= this.ColumnName.GetHashCode();
      if (this.TableName != null)
        hashCode ^= this.TableName.GetHashCode();
      return hashCode ^ this.RowIndex.GetHashCode();
    }

    public override PropertyMap Clone()
    {
      return (PropertyMap) new InlinePropertyMap(this);
    }
  }
}
