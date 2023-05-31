
/*
 * Static global variables.
 */
namespace JpLayoutFixer {
    static class Global {
        private static bool jp = false;

        public static bool Jp {
            get { return jp; }
            set { jp = value; }
        }
    }
}
