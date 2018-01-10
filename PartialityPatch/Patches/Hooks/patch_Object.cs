using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Partiality;

namespace UnityEngine.mm.Patches.Hooks {
    [MonoMod.MonoModPatch("global:UnityEngine.Object")]
    class patch_Object {

        public extern void orig_ctor_Object();
        [MonoMod.MonoModConstructor]
        public void ctor_Object() {
            orig_ctor_Object();

            Debug.Log("Let's hook some code!");
            PartialityManager.CreateInstance();
        }
    }
}
