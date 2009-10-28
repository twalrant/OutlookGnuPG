using System;

namespace CC.OutlookGnuPG
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
        public uint Format { get; set; }

        /// <summary>
        /// Get or Set the format name of the data 
        /// </summary>
        public string FormatName { get; set; }

        /// <summary>
        /// Get or Set the buffer data
        /// </summary>
        public byte[] Buffer { get; set; }

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