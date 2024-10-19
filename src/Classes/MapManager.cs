using System;

namespace NotEnoughMadness.Classes
{
    public static class MapManager
    {
        // All nem map components are subscribed to those 2 events by default
        // When the scene loads:
        // OnCreateMapComponents gets fired
        // all the components create their stuff
        // OnConnectMapComponents gets fired
        // all the nem components connect references to the newly created vanilla components
        // nem components self destruct


        // Other mods can also subscribe to those events if they want to extend vanilla functionality 😱😱😱😱


        public static EventHandler OnCreateMapComponents = delegate { };
        public static EventHandler OnConnectMapComponents = delegate { };

        static void CreateMapComponents()
        {
            OnCreateMapComponents(null, EventArgs.Empty);
        }

        static void ConnectMapComponents()
        {
            OnConnectMapComponents(null, EventArgs.Empty);
        }

        static void ClearMapEvents()
        {
            OnCreateMapComponents = delegate { };
            OnConnectMapComponents = delegate { };
        }

        public static void ProcessMapComponents()
        {
            // It is important all this stuff happens here in one place, or else we run into race conditions and looped dependencies and stuff 

            // All vanilla components are created from nem components
            CreateMapComponents();
            // Nem components create connections / references between vanilla components
            ConnectMapComponents();
            // Unsubscribe all components from the events
            ClearMapEvents();
        }
    }
}
