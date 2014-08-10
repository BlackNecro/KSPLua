using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLua;


namespace KSPLua
{
    public static class NLuaExtensions
    {
        public static LuaTable CreateTable(this Lua luaInst)
        {
            return (LuaTable) luaInst.DoString("return {}")[0];
        }
    }
}
