using UnityEngine;
using System;
using System.Reflection;
using System.Text;
using System.IO;
using System.Net; 


public class BaseClass
{
	public enum ePackingLength
	{
		PL_MAX = 4096,
	};

	public static byte[] StringToByteArray( string str, int length )
	{
		return Encoding.ASCII.GetBytes( str.PadRight( length, '\0' ) );
	}

	public static char[] StringToCharArray( string str, int length )
	{
		return Encoding.ASCII.GetChars( StringToByteArray( str, length ) );
	}

	#region new
	public byte[] ClassToByteArray()
	{
		byte[] data = new byte[(int)ePackingLength.PL_MAX];
		byte[] tmpData;
		int size = 0;
		MemoryStream ms = new MemoryStream( data );
		BinaryWriter bw = new BinaryWriter( ms );

		Type infotype = this.GetType();
		FieldInfo[] infolist = infotype.GetFields( BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.DeclaredOnly );
		foreach( FieldInfo info in infolist )
		{
			if( info.FieldType.IsArray == false )
			{
				switch( Convert.ToString( info.FieldType ) )
				{
				case "System.Boolean":	bw.Write( (Boolean)info.GetValue( this ) );	break;
				case "System.Byte":	bw.Write( (Byte)info.GetValue( this ) );	break;
				case "System.Char":	bw.Write( (Char)info.GetValue( this ) );	break;
				case "System.Int16":	bw.Write( (Int16)info.GetValue( this ) );	break;
				case "System.UInt16":	bw.Write( (UInt16)info.GetValue( this ) );	break;
				case "System.Int32":	bw.Write( (Int32)info.GetValue( this ) );	break;
				case "System.UInt32":	bw.Write( (UInt32)info.GetValue( this ) );	break;
				case "System.Int64":	bw.Write( (Int64)info.GetValue( this ) );	break;
				case "System.UInt64":	bw.Write( (UInt64)info.GetValue( this ) );	break;
				case "System.Single":	bw.Write( (Single)info.GetValue( this ) );	break;
				case "System.Double":	bw.Write( (double)info.GetValue( this ) );	break;
				case "UnityEngine.Vector3":
					Vector3 v3 = (Vector3)info.GetValue(this);
					bw.Write(v3.x);
					bw.Write(v3.y);
					bw.Write(v3.z);
					break;
				//case "eGENDER": bw.Write( (Int32)info.GetValue( this));	break;				
				default:
					if( Convert.ToString( info.FieldType.BaseType ) == "BaseClass" )
					{
						tmpData = ( (BaseClass)info.GetValue( this ) ).ClassToByteArray();
						bw.Write( tmpData );
					}
					break;
				}
			}
			else
			{
				switch( Convert.ToString( info.FieldType ) )
				{
				case "System.Boolean[]":
					{
						bw.Write( (Boolean)info.GetValue( this ) );
					}
					break;
				case "System.Byte[]":
					{
						size = ( (Byte[])info.GetValue( this ) ).GetLength( 0 );
						Byte[] tmpByte = (Byte[])info.GetValue( this );
						bw.Write( tmpByte );
					}
					break;
				case "System.Char[]":
					{
						size = ( (Char[])info.GetValue( this ) ).GetLength( 0 );
						Char[] tmpChar = (Char[])info.GetValue( this );
						tmpData = new byte[2 * size];
						Buffer.BlockCopy( tmpChar, 0, tmpData, 0, tmpData.Length );
						bw.Write( tmpData );
					}
					break;
				case "System.Int16[]":
					{
						size = ( (Int16[])info.GetValue( this ) ).GetLength( 0 );
						Int16[] tmpInt16 = (Int16[])info.GetValue( this );
						tmpData = new byte[4 * size];
						Buffer.BlockCopy( tmpInt16, 0, tmpData, 0, tmpData.Length );
						bw.Write( tmpData );
					}
					break;
				case "System.UInt16[]":
					{
						size = ( (UInt16[])info.GetValue( this ) ).GetLength( 0 );
						UInt16[] tmpUInt16 = (UInt16[])info.GetValue( this );
						tmpData = new byte[4 * size];
						Buffer.BlockCopy( tmpUInt16, 0, tmpData, 0, tmpData.Length );
						bw.Write( tmpData );
					}
					break;
				case "System.Int32[]":
					{
						size = ( (Int32[])info.GetValue( this ) ).GetLength( 0 );
						Int32[] tmpInt32 = (Int32[])info.GetValue( this );
						tmpData = new byte[4 * size];
						Buffer.BlockCopy( tmpInt32, 0, tmpData, 0, tmpData.Length );
						bw.Write( tmpData );
					}
					break;
				case "System.UInt32[]":
					{
						size = ( (UInt32[])info.GetValue( this ) ).GetLength( 0 );
						UInt32[] tmpUInt32 = (UInt32[])info.GetValue( this );
						tmpData = new byte[4 * size];
						Buffer.BlockCopy( tmpUInt32, 0, tmpData, 0, tmpData.Length );
						bw.Write( tmpData );
					}
					break;
				case "System.Int64[]":
					{
						size = ( (Int64[])info.GetValue( this ) ).GetLength( 0 );
						Int64[] tmpInt64 = (Int64[])info.GetValue( this );
						tmpData = new byte[8 * size];
						Buffer.BlockCopy( tmpInt64, 0, tmpData, 0, tmpData.Length );
						bw.Write( tmpData );
					}
					break;
				case "System.Single[]":
					{
						size = ( (Single[])info.GetValue( this ) ).GetLength( 0 );
						Single[] tmpSingle = (Single[])info.GetValue( this );
						tmpData = new byte[4 * size];
						Buffer.BlockCopy( tmpSingle, 0, tmpData, 0, tmpData.Length );
						bw.Write( tmpData );
					}
					break;
				case "System.Double[]":
					{
						size = ( (Double[])info.GetValue( this ) ).GetLength( 0 );
						Double[] tmpDouble = (Double[])info.GetValue( this );
						tmpData = new byte[8 * size];
						Buffer.BlockCopy( tmpDouble, 0, tmpData, 0, tmpData.Length );
						bw.Write( tmpData );
					}
					break;
				default:
					{
						if( Convert.ToString( info.FieldType.BaseType ) == "System.Array" )
						{
							BaseClass[] tmpClass = (BaseClass[])info.GetValue( this );
							int i = 0;
							foreach( BaseClass it in tmpClass )
							{
								++i;
								tmpData = it.ClassToByteArray();
								bw.Write( tmpData );
							}
						}
					}
					break;
				}
			}
		}
		
//		Debug.Log( "Size : " + ms.Position);
		tmpData = new byte[(int)ms.Position];
		Buffer.BlockCopy( data, 0, tmpData, 0, tmpData.Length );

		bw.Close();
		ms.Close();

		return tmpData;
	}

	public int ByteArrayToClass( byte[] data )
	{
		byte[] tmpData;
		int size = 0;
		MemoryStream ms = new MemoryStream( data );
		BinaryReader br = new BinaryReader( ms );
		Type infotype = this.GetType();
		FieldInfo[] infolist = infotype.GetFields( BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.DeclaredOnly );
		foreach( FieldInfo info in infolist )
		{
			if( info.FieldType.IsArray == false )
			{
				string type = Convert.ToString( info.FieldType);
				
				switch( type )
				{
				case "System.Boolean":
					info.SetValue( this, br.ReadBoolean() );
					break;
				case "System.Byte":
					info.SetValue( this, br.ReadByte() );
					break;
				case "System.Char":
					info.SetValue( this, br.ReadChar() );
					break;
				case "System.Int16":
					info.SetValue( this, br.ReadInt16() );
					break;
				case "System.UInt16":
					info.SetValue( this, br.ReadUInt16() );
					break;
				case "System.Int32":
					info.SetValue( this, br.ReadInt32() );
					break;
				case "System.UInt32":
					info.SetValue( this, br.ReadUInt32() );
					break;
				case "System.Int64":
					info.SetValue( this, br.ReadInt64() );
					break;
				case "System.UInt64":
					info.SetValue( this, br.ReadUInt64() );
					break;
				case "System.Single":
					info.SetValue( this, br.ReadSingle() );
					break;
				case "System.Double":
					info.SetValue( this, br.ReadDouble() );
					break;
				//case "eBUFFTYPE":
				//	info.SetValue( this, br.ReadInt32() );
				//	break;						
				case "UnityEngine.Vector3":
					{
						tmpData = new byte[sizeof( float ) * 3];
						br.Read( tmpData, 0, tmpData.Length );
						Single[] tmpSingle = new Single[3];
						Buffer.BlockCopy( tmpData, 0, tmpSingle, 0, tmpData.Length );
						Vector3 v = new Vector3(tmpSingle[0], tmpSingle[1], tmpSingle[2]);
						info.SetValue( this, v );
					}
					break;				
				/*case "sITEMVIEW":
					sITEMVIEW itemview = new sITEMVIEW();
					tmpData = new byte[sITEMVIEW.size];
					br.Read( tmpData, 0, tmpData.Length );
					itemview.ByteArrayToClass(tmpData);
					info.SetValue(this, itemview);
					break;*/
				default:
					{
						if( Convert.ToString( info.FieldType.BaseType ) == "BaseClass" )
						{
							tmpData = new byte[data.Length - (int)ms.Position];
							Buffer.BlockCopy( data, (int)ms.Position, tmpData, 0, tmpData.Length );
							ms.Position += ( (BaseClass)info.GetValue( this ) ).ByteArrayToClass( tmpData );
						}
					}
					break;
				}
			}
			else
			{
				switch( Convert.ToString( info.FieldType ) )
				{
				case "System.Boolean[]":
					{
						size = ( (Boolean[])info.GetValue( this ) ).GetLength( 0 );
						tmpData = new byte[4 * size];
						br.Read( tmpData, 0, tmpData.Length );
						Boolean[] tmpBoolean = new Boolean[size];
						Buffer.BlockCopy( tmpData, 0, tmpBoolean, 0, tmpData.Length );
						info.SetValue( this, tmpBoolean );
					}
					break;
				case "System.Byte[]":
					{
						size = ( (Byte[])info.GetValue( this ) ).GetLength( 0 );
						info.SetValue( this, br.ReadBytes( size ) );
					}
					break;
				case "System.Char[]":
					{
						size = ( (Char[])info.GetValue( this ) ).GetLength( 0 );
						info.SetValue( this, br.ReadChars( size * 2 ) );
					}
					break;
				case "System.Int16[]":
					{
						size = ( (Int16[])info.GetValue( this ) ).GetLength( 0 );
						tmpData = new byte[2 * size];
						br.Read( tmpData, 0, tmpData.Length );
						Int16[] tmpInt16 = new Int16[size];
						Buffer.BlockCopy( tmpData, 0, tmpInt16, 0, tmpData.Length );
						info.SetValue( this, tmpInt16 );
					}
					break;
				case "System.UInt16[]":
					{
						size = ( (UInt16[])info.GetValue( this ) ).GetLength( 0 );
						tmpData = new byte[2 * size];
						br.Read( tmpData, 0, tmpData.Length );
						UInt16[] tmpUInt16 = new UInt16[size];
						Buffer.BlockCopy( tmpData, 0, tmpUInt16, 0, tmpData.Length );
						info.SetValue( this, tmpUInt16 );
					}
					break;
				case "System.Int32[]":
					{
						size = ( (Int32[])info.GetValue( this ) ).GetLength( 0 );
						tmpData = new byte[4 * size];
						br.Read( tmpData, 0, tmpData.Length );
						Int32[] tmpInt32 = new Int32[size];
						Buffer.BlockCopy( tmpData, 0, tmpInt32, 0, tmpData.Length );
						info.SetValue( this, tmpInt32 );
					}
					break;
				case "System.UInt32[]":
					{
						size = ( (UInt32[])info.GetValue( this ) ).GetLength( 0 );
						tmpData = new byte[4 * size];
						br.Read( tmpData, 0, size );
						UInt32[] tmpUInt32 = new UInt32[size];
						Buffer.BlockCopy( tmpData, 0, tmpUInt32, 0, tmpData.Length );
						info.SetValue( this, tmpUInt32 );
					}
					break;
				case "System.Int64[]":
					{
						size = ( (Int64[])info.GetValue( this ) ).GetLength( 0 );
						tmpData = new byte[8 * size];
						br.Read( tmpData, 0, tmpData.Length );
						Int64[] tmpInt64 = new Int64[size];
						Buffer.BlockCopy( tmpData, 0, tmpInt64, 0, tmpData.Length );
						info.SetValue( this, tmpInt64 );
					}
					break;
				case "System.Single[]":
					{
						size = ( (Single[])info.GetValue( this ) ).GetLength( 0 );
						tmpData = new byte[4 * size];
						br.Read( tmpData, 0, tmpData.Length );
						Single[] tmpSingle = new Single[size];
						Buffer.BlockCopy( tmpData, 0, tmpSingle, 0, tmpData.Length );
						info.SetValue( this, tmpSingle );
					}
					break;
				case "System.Double[]":
					{
						size = ( (Double[])info.GetValue( this ) ).GetLength( 0 );
						tmpData = new byte[8 * size];
						br.Read( tmpData, 0, tmpData.Length );
						Double[] tmpDouble = new Double[size];
						Buffer.BlockCopy( tmpData, 0, tmpDouble, 0, tmpData.Length );
						info.SetValue( this, tmpDouble );
					}
					break;			
				default:
					{
						if( Convert.ToString( info.FieldType.BaseType ) == "System.Array" )
						{
							BaseClass[] tmpClass = (BaseClass[])info.GetValue( this );
							foreach( BaseClass it in tmpClass )
							{
								if( data.Length - (int)ms.Position <= 0 )
									break;

								tmpData = new byte[data.Length - (int)ms.Position];
								Buffer.BlockCopy( data, (int)ms.Position, tmpData, 0, tmpData.Length );
								ms.Position += it.ByteArrayToClass( tmpData );
							}
						}
					}
					break;
				}
			}
		}

		int index = (int)ms.Position;
		br.Close();
		ms.Close();

		return index;
	}
	#endregion

	public byte[] ClassToPacketBytes()
	{
		byte[] data = new byte[(int)ePackingLength.PL_MAX];
		byte[] tmpData;
		int index = 2;

		Type infotype = this.GetType();

		// 서버와의 문제로 순서 바꿔서 집어 넣음 ( Protocol, Category -> Category, Protocol)
		FieldInfo headerinfo = infotype.GetField( "Protocol", BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField );
		data[index++] = (byte)headerinfo.GetValue( this );

		headerinfo = infotype.GetField( "Category", BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField );
		data[index++] = (byte)headerinfo.GetValue( this );

		tmpData = ClassToByteArray();

		Buffer.BlockCopy( tmpData, 0, data, index, tmpData.Length );
		index += tmpData.Length;

		int dataLength = tmpData.Length;

		tmpData = new byte[2];
		//tmpData = BitConverter.GetBytes( (ushort)index );
		// 패킷의 길이는 순수하게 데이터의 길이만 집어 넣음
		tmpData = BitConverter.GetBytes( (ushort)dataLength);
		Buffer.BlockCopy( tmpData, 0, data, 0, 2 );

		tmpData = new byte[index];
		Array.Copy( data, tmpData, index );

		return tmpData;
	}

	public void PacketBytesToClass( byte[] data )
	{
		byte[] tmpData = new byte[2];
		int index = 0;
		ushort tmpUs = 0;

		Type infotype = this.GetType();
		FieldInfo headerinfo = infotype.GetField( "Size", BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField );
		Buffer.BlockCopy( data, index, tmpData, 0, 2 );
		tmpUs = BitConverter.ToUInt16( tmpData, index );
		index += 2;
		headerinfo.SetValue( this, tmpUs );

		headerinfo = infotype.GetField( "Protocol", BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField );
		headerinfo.SetValue( this, data[index++] );

		headerinfo = infotype.GetField( "Category", BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField );
		headerinfo.SetValue( this, data[index++] );

		tmpData = new byte[data.Length - index];
		Buffer.BlockCopy( data, index, tmpData, 0, tmpData.Length );
		ByteArrayToClass( tmpData );
	}
}

public class PacketHeader : BaseClass
{
	public ushort Size = 0;
	public byte Category = 0;
	public byte Protocol = 0;
}