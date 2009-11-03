using System;

namespace OutlookGnuPG
{
  /// <summary>
  /// Holds clipboard data of a single data format.
  /// </summary>
  [Serializable]
  public class DataClip
  {
    /// <summary>
    /// Get or Set the format code of the data 
    /// </summary>
    private uint m_Format;
    public uint Format { get { return m_Format; } set { m_Format = value; } }

    /// <summary>
    /// Get or Set the format name of the data 
    /// </summary>
    private string m_FormatName;
    public string FormatName { get { return m_FormatName; } set { m_FormatName = value; } }

    /// <summary>
    /// Get or Set the buffer data
    /// </summary>
    private byte[] m_Buffer;
    public byte[] Buffer { get { return m_Buffer; } set { m_Buffer = value; } }

    private readonly int _size;

    /// <summary>
    /// Get the data buffer lenght
    /// </summary>
    public UIntPtr Size
    {
      get
      {
        return Buffer != null
                ? new UIntPtr(Convert.ToUInt32(Buffer.GetLength(0)))
                : new UIntPtr(Convert.ToUInt32(_size));
      }
    }
    /// <summary>
    /// Init a Clip Data object, containing one clipboard data and its format
    /// </summary>
    /// <param name="format"></param>
    /// <param name="formatName"></param>
    /// <param name="buffer"></param>
    public DataClip(uint format, string formatName, byte[] buffer)
    {
      Format = format;
      FormatName = formatName;
      Buffer = buffer;
      _size = 0;
    }
  }
}