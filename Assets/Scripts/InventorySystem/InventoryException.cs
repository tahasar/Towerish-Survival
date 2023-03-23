using System;
using Unity.VisualScripting;

namespace InventorySystem
{
    public class InventoryException : Exception
    {
        public enum InventoryOperation
        {
            Add,
            Remove
        }
        
        public InventoryOperation Operation { get; }
        
        public InventoryException(InventoryOperation operation, string msg) : base($"{operation} Error: {msg}")
        {
            Operation = operation;
        }
    }
}