using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    public class ByteArrayManagement
    {
        private byte[] _newlyCreatedByteArray;
        private byte[] _pooledByteArray;
        private ArrayPool<byte> byteArrayPool;
        const int maxArraysPerBucket = 10;

        public void SimulateCreationOfByteArrayPool(int length, int executionCount)
        {
            CreateByteArrayPool(length);
            for (int i = 0; i < executionCount; i++)
            {
                RentByteArrayPool(length);
                LoadByteArray(_pooledByteArray);
                ReleaseByteArrayPool(_pooledByteArray);
            }
        }

        private void CreateByteArrayPool(int length)
        {
            byteArrayPool = ArrayPool<byte>.Create(length, maxArraysPerBucket);
        }

        private void RentByteArrayPool(int length)
        {
            _pooledByteArray = byteArrayPool.Rent(length);
        }

        private void ReleaseByteArrayPool(byte[] aByte)
        {
            byteArrayPool.Return(aByte, true);
        }

        public void SimulateCreationOfByteArrays(int length, int executionCount)
        {
            for(int i = 0; i < executionCount; i++)
            {
                CreateByteArrays(length);
                LoadByteArray(_newlyCreatedByteArray);
            }
        }

        private void CreateByteArrays(int length)
        {
            _newlyCreatedByteArray = new byte[length];
        }

        private void LoadByteArray(byte[] aBytes)
        {
            for (var i = 0; i < aBytes.Length; i++)
            {
                aBytes[i] = Byte.MaxValue;
            }
        }


    }
}
