using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Partiality;

namespace UnityEngine.mm.Patches.Hooks {
    [MonoMod.MonoModPatch( "global::UnityEngine.Object" )]
    class patch_Object: Object {

        [MonoMod.MonoModIgnore]
        public static int OffsetOfInstanceIDInCPlusPlusObject;

        [MonoMod.MonoModConstructor]
        public static void cctor_Object() {
            OffsetOfInstanceIDInCPlusPlusObject = -1;

            Debug.Log( "Let's hook some code!" );
            try {
                PartialityManager.CreateInstance();
            } catch( System.Exception e ) {
                Debug.LogError(e);
                File.WriteAllText( Application.dataPath + "/errorPartiality.txt", e.ToString() );
            }
        }
    }
}
