/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_BGMUSIC = 2384134264U;
        static const AkUniqueID PLAY_CAR = 2690797144U;
        static const AkUniqueID PLAY_COFFEE_SHOP_AMBIENT = 2014237476U;
        static const AkUniqueID PLAY_DOORS = 3655372345U;
        static const AkUniqueID PLAY_ENEMY_DEATH = 3046156865U;
        static const AkUniqueID PLAY_ENEMY_GRUNTS = 4166385128U;
        static const AkUniqueID PLAY_FINISHED = 1966697128U;
        static const AkUniqueID PLAY_GAMEOVER = 3174629258U;
        static const AkUniqueID PLAY_ITEM_PICKUPS = 325112345U;
        static const AkUniqueID PLAY_PLAYER_DAMAGE = 3638125099U;
        static const AkUniqueID PLAY_PLAYER_JUMP = 562256996U;
        static const AkUniqueID PLAY_PLAYER_WALKING = 4033055653U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace STATE
            {
                static const AkUniqueID COFFEE_SHOP = 219143000U;
                static const AkUniqueID GAMEOVER = 4158285989U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PLAYING = 1852808225U;
                static const AkUniqueID WON = 1080430619U;
            } // namespace STATE
        } // namespace MUSIC

    } // namespace STATES

    namespace SWITCHES
    {
        namespace SCENES
        {
            static const AkUniqueID GROUP = 1544306542U;

            namespace SWITCH
            {
                static const AkUniqueID INDOORS = 4103860031U;
                static const AkUniqueID OUTDOORS = 2730119150U;
            } // namespace SWITCH
        } // namespace SCENES

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PLAYERHEALTH = 151362964U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID DEFAULT = 782826392U;
        static const AkUniqueID LEVEL2 = 2678230381U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID REVERB = 348963605U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
