using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;

static partial class Utility
{
    [JSImport("utility.glBufferData", "main.js")]
    public static partial void GlBufferData(int target,
                                            [JSMarshalAs<MemoryView>] Span<byte> data,
                                            int usage);
}
