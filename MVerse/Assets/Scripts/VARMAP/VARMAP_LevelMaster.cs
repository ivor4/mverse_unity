using RamsesTheThird.VARMAP.Types;
using RamsesTheThird.VARMAP.Types.Delegates;

namespace RamsesTheThird.VARMAP.LevelMaster
{
    public abstract class VARMAP_LevelMaster : VARMAP
    {
        /* All delegate update */
        public static void UpdateDelegates()
        {
            /* > ATG 1 START */
            GET_GAME_OPTIONS = _GET_GAME_OPTIONS;
            GET_ELEM_POWERS = _GET_ELEM_POWERS;
            SET_ELEM_POWERS = _SET_ELEM_POWERS;
            GET_SIZE_POWERS = _GET_SIZE_POWERS;
            GET_ARRAY_POWERS = _GET_ARRAY_POWERS;
            SET_ARRAY_POWERS = _SET_ARRAY_POWERS;
            GET_ELAPSED_TIME_MS = _GET_ELAPSED_TIME_MS;
            GET_ACTUAL_ROOM = _GET_ACTUAL_ROOM;
            GET_ELEM_ITEMS_COLLECTED = _GET_ELEM_ITEMS_COLLECTED;
            GET_SIZE_ITEMS_COLLECTED = _GET_SIZE_ITEMS_COLLECTED;
            GET_ARRAY_ITEMS_COLLECTED = _GET_ARRAY_ITEMS_COLLECTED;
            GET_ELEM_EVENTS_OCCURRED = _GET_ELEM_EVENTS_OCCURRED;
            GET_SIZE_EVENTS_OCCURRED = _GET_SIZE_EVENTS_OCCURRED;
            GET_ARRAY_EVENTS_OCCURRED = _GET_ARRAY_EVENTS_OCCURRED;
            GET_ELEM_SELECTED_CHARMS = _GET_ELEM_SELECTED_CHARMS;
            SET_ELEM_SELECTED_CHARMS = _SET_ELEM_SELECTED_CHARMS;
            GET_SIZE_SELECTED_CHARMS = _GET_SIZE_SELECTED_CHARMS;
            GET_ARRAY_SELECTED_CHARMS = _GET_ARRAY_SELECTED_CHARMS;
            SET_ARRAY_SELECTED_CHARMS = _SET_ARRAY_SELECTED_CHARMS;
            GET_OTHER_WORLD = _GET_OTHER_WORLD;
            SET_OTHER_WORLD = _SET_OTHER_WORLD;
            GET_OTHER_WORLD_TRANSITION_ACTIVE = _GET_OTHER_WORLD_TRANSITION_ACTIVE;
            SET_OTHER_WORLD_TRANSITION_ACTIVE = _SET_OTHER_WORLD_TRANSITION_ACTIVE;
            GET_OTHER_WORLD_TRANSITION_PROGRESS = _GET_OTHER_WORLD_TRANSITION_PROGRESS;
            SET_OTHER_WORLD_TRANSITION_PROGRESS = _SET_OTHER_WORLD_TRANSITION_PROGRESS;
            GET_OTHER_WORLD_MODE = _GET_OTHER_WORLD_MODE;
            SET_OTHER_WORLD_MODE = _SET_OTHER_WORLD_MODE;
            GET_GAMESTATUS = _GET_GAMESTATUS;
            REG_GAMESTATUS = _REG_GAMESTATUS;
            UNREG_GAMESTATUS = _UNREG_GAMESTATUS;
            LOAD_ROOM = _LOAD_ROOM;
            LOADING_COMPLETED = _LOADING_COMPLETED;
            CHANGE_OTHER_WORLD = _CHANGE_OTHER_WORLD;
            FREEZE_PLAY = _FREEZE_PLAY;
            ENEMY_REGISTER = _ENEMY_REGISTER;
            /* > ATG 1 END */
        }



        /* GET/SET */
        /* > ATG 2 START */
        public static GetVARMAPValueDelegate<GameOptionsStruct> GET_GAME_OPTIONS;
        public static GetVARMAPArrayElemValueDelegate<bool> GET_ELEM_POWERS;
        public static SetVARMAPArrayElemValueDelegate<bool> SET_ELEM_POWERS;
        public static GetVARMAPArraySizeDelegate GET_SIZE_POWERS;
        public static GetVARMAPArrayDelegate<bool> GET_ARRAY_POWERS;
        public static SetVARMAPArrayDelegate<bool> SET_ARRAY_POWERS;
        public static GetVARMAPValueDelegate<ulong> GET_ELAPSED_TIME_MS;
        public static GetVARMAPValueDelegate<Room> GET_ACTUAL_ROOM;
        public static GetVARMAPArrayElemValueDelegate<ulong> GET_ELEM_ITEMS_COLLECTED;
        public static GetVARMAPArraySizeDelegate GET_SIZE_ITEMS_COLLECTED;
        public static GetVARMAPArrayDelegate<ulong> GET_ARRAY_ITEMS_COLLECTED;
        public static GetVARMAPArrayElemValueDelegate<ulong> GET_ELEM_EVENTS_OCCURRED;
        public static GetVARMAPArraySizeDelegate GET_SIZE_EVENTS_OCCURRED;
        public static GetVARMAPArrayDelegate<ulong> GET_ARRAY_EVENTS_OCCURRED;
        public static GetVARMAPArrayElemValueDelegate<byte> GET_ELEM_SELECTED_CHARMS;
        public static SetVARMAPArrayElemValueDelegate<byte> SET_ELEM_SELECTED_CHARMS;
        public static GetVARMAPArraySizeDelegate GET_SIZE_SELECTED_CHARMS;
        public static GetVARMAPArrayDelegate<byte> GET_ARRAY_SELECTED_CHARMS;
        public static SetVARMAPArrayDelegate<byte> SET_ARRAY_SELECTED_CHARMS;
        public static GetVARMAPValueDelegate<bool> GET_OTHER_WORLD;
        public static SetVARMAPValueDelegate<bool> SET_OTHER_WORLD;
        public static GetVARMAPValueDelegate<bool> GET_OTHER_WORLD_TRANSITION_ACTIVE;
        public static SetVARMAPValueDelegate<bool> SET_OTHER_WORLD_TRANSITION_ACTIVE;
        public static GetVARMAPValueDelegate<float> GET_OTHER_WORLD_TRANSITION_PROGRESS;
        public static SetVARMAPValueDelegate<float> SET_OTHER_WORLD_TRANSITION_PROGRESS;
        public static GetVARMAPValueDelegate<OtherWorldMode> GET_OTHER_WORLD_MODE;
        public static SetVARMAPValueDelegate<OtherWorldMode> SET_OTHER_WORLD_MODE;
        public static GetVARMAPValueDelegate<Game_Status> GET_GAMESTATUS;
        public static ReUnRegisterVARMAPValueChangeEventDelegate<Game_Status> REG_GAMESTATUS;
        public static ReUnRegisterVARMAPValueChangeEventDelegate<Game_Status> UNREG_GAMESTATUS;
        /* > ATG 2 END */

        /* SERVICES */
        /* > ATG 3 START */
        public static LOAD_ROOM_DELEGATE LOAD_ROOM;
        public static LODING_COMPLETED_DELEGATE LOADING_COMPLETED;
        public static CHANGE_OTHER_WORLD_DELEGATE CHANGE_OTHER_WORLD;
        public static FREEZE_PLAY_DELEGATE FREEZE_PLAY;
        public static ENEMY_REGISTER_SERVICE ENEMY_REGISTER;
        /* > ATG 3 END */
    }
}
