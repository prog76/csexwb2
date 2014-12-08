using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    #region IMalloc Interface

    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000002-0000-0000-C000-000000000046")]
    public interface IMalloc
    {
        // Allocate a block of memory
        // Return value: a pointer to the allocated memory block.
        [PreserveSig]
        IntPtr Alloc(UInt32 cb); // Size, in bytes, of the memory block to be allocated.

        // Changes the size of a previously allocated memory block.
        // Return value: reallocated memory block
        [PreserveSig]
        IntPtr Realloc(
            IntPtr pv,  // Pointer to the memory block to be reallocated
            UInt32 cb); // Size of the memory block, in bytes, to be 
        // reallocated.

        // Free a previously allocated block of memory.
        [PreserveSig]
        void Free(IntPtr pv); // Pointer to the memory block to be freed.

        // This method returns the size, in bytes, of a memory block 
        // previously
        // allocated with IMalloc::Alloc or IMalloc::Realloc.
        // Return value: The size of the allocated memory block in bytes.
        [PreserveSig]
        UInt32 GetSize(IntPtr pv); // Pointer to the memory block for which the size is  requested.

        // This method determines whether this allocator was used to allocate
        // the specified block of memory.
        // Return value: 1 - allocated 0 - not allocated by this IMalloc Instance.
        [PreserveSig]
        Int16 DidAlloc(IntPtr pv); // Pointer to the memory block

        // Minimizes the heap by releasing unused memory to the operating system.
        [PreserveSig]
        void HeapMinimize();
    }

    #endregion
}