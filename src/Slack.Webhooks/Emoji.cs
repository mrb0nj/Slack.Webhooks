using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Slack.Webhooks

{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Emoji

    {
        [EnumMember(Value = null)]
        None = 0,
        [EnumMember(Value = ":+1:")]
        PlusOne,
        [EnumMember(Value = ":-1:")]
        MinusOne,
        [EnumMember(Value = ":100:")]
        OneHundred,
        [EnumMember(Value = ":1234:")]
        OneTwoThreeFour,
        [EnumMember(Value = ":8ball:")]
        EightBall,
        [EnumMember(Value = ":a:")]
        A,
        [EnumMember(Value = ":ab:")]
        Ab,
        [EnumMember(Value = ":abc:")]
        Abc,
        [EnumMember(Value = ":abcd:")]
        Abcd,
        [EnumMember(Value = ":accept:")]
        Accept,
        [EnumMember(Value = ":aerial_tramway:")]
        AerialTramway,
        [EnumMember(Value = ":airplane:")]
        Airplane,
        [EnumMember(Value = ":alarm_clock:")]
        AlarmClock,
        [EnumMember(Value = ":alien:")]
        Alien,
        [EnumMember(Value = ":ambulance:")]
        Ambulance,
        [EnumMember(Value = ":anchor:")]
        Anchor,
        [EnumMember(Value = ":angel:")]
        Angel,
        [EnumMember(Value = ":anger:")]
        Anger,
        [EnumMember(Value = ":angry:")]
        Angry,
        [EnumMember(Value = ":anguished:")]
        Anguished,
        [EnumMember(Value = ":ant:")]
        Ant,
        [EnumMember(Value = ":apple:")]
        Apple,
        [EnumMember(Value = ":aquarius:")]
        Aquarius,
        [EnumMember(Value = ":aries:")]
        Aries,
        [EnumMember(Value = ":arrow_backward:")]
        ArrowBackward,
        [EnumMember(Value = ":arrow_double_down:")]
        ArrowDoubleDown,
        [EnumMember(Value = ":arrow_double_up:")]
        ArrowDoubleUp,
        [EnumMember(Value = ":arrow_down:")]
        ArrowDown,
        [EnumMember(Value = ":arrow_down_small:")]
        ArrowDownSmall,
        [EnumMember(Value = ":arrow_forward:")]
        ArrowForward,
        [EnumMember(Value = ":arrow_heading_down:")]
        ArrowHeadingDown,
        [EnumMember(Value = ":arrow_heading_up:")]
        ArrowHeadingUp,
        [EnumMember(Value = ":arrow_left:")]
        ArrowLeft,
        [EnumMember(Value = ":arrow_lower_left:")]
        ArrowLowerLeft,
        [EnumMember(Value = ":arrow_lower_right:")]
        ArrowLowerRight,
        [EnumMember(Value = ":arrow_right:")]
        ArrowRight,
        [EnumMember(Value = ":arrow_right_hook:")]
        ArrowRightHook,
        [EnumMember(Value = ":arrow_up:")]
        ArrowUp,
        [EnumMember(Value = ":arrow_up_down:")]
        ArrowUpDown,
        [EnumMember(Value = ":arrow_up_small:")]
        ArrowUpSmall,
        [EnumMember(Value = ":arrow_upper_left:")]
        ArrowUpperLeft,
        [EnumMember(Value = ":arrow_upper_right:")]
        ArrowUpperRight,
        [EnumMember(Value = ":arrows_clockwise:")]
        ArrowsClockwise,
        [EnumMember(Value = ":arrows_counterclockwise:")]
        ArrowsCounterclockwise,
        [EnumMember(Value = ":art:")]
        Art,
        [EnumMember(Value = ":articulated_lorry:")]
        ArticulatedLorry,
        [EnumMember(Value = ":astonished:")]
        Astonished,
        [EnumMember(Value = ":atm:")]
        Atm,
        [EnumMember(Value = ":b:")]
        B,
        [EnumMember(Value = ":baby:")]
        Baby,
        [EnumMember(Value = ":baby_bottle:")]
        BabyBottle,
        [EnumMember(Value = ":baby_chick:")]
        BabyChick,
        [EnumMember(Value = ":baby_symbol:")]
        BabySymbol,
        [EnumMember(Value = ":back:")]
        Back,
        [EnumMember(Value = ":baggage_claim:")]
        BaggageClaim,
        [EnumMember(Value = ":balloon:")]
        Balloon,
        [EnumMember(Value = ":ballot_box_with_check:")]
        BallotBoxWithCheck,
        [EnumMember(Value = ":bamboo:")]
        Bamboo,
        [EnumMember(Value = ":banana:")]
        Banana,
        [EnumMember(Value = ":bangbang:")]
        Bangbang,
        [EnumMember(Value = ":bank:")]
        Bank,
        [EnumMember(Value = ":bar_chart:")]
        BarChart,
        [EnumMember(Value = ":barber:")]
        Barber,
        [EnumMember(Value = ":baseball:")]
        Baseball,
        [EnumMember(Value = ":basketball:")]
        Basketball,
        [EnumMember(Value = ":bath:")]
        Bath,
        [EnumMember(Value = ":bathtub:")]
        Bathtub,
        [EnumMember(Value = ":battery:")]
        Battery,
        [EnumMember(Value = ":bear:")]
        Bear,
        [EnumMember(Value = ":bee:")]
        Bee,
        [EnumMember(Value = ":beer:")]
        Beer,
        [EnumMember(Value = ":beers:")]
        Beers,
        [EnumMember(Value = ":beetle:")]
        Beetle,
        [EnumMember(Value = ":beginner:")]
        Beginner,
        [EnumMember(Value = ":bell:")]
        Bell,
        [EnumMember(Value = ":bento:")]
        Bento,
        [EnumMember(Value = ":bicyclist:")]
        Bicyclist,
        [EnumMember(Value = ":bike:")]
        Bike,
        [EnumMember(Value = ":bikini:")]
        Bikini,
        [EnumMember(Value = ":bird:")]
        Bird,
        [EnumMember(Value = ":birthday:")]
        Birthday,
        [EnumMember(Value = ":black_circle:")]
        BlackCircle,
        [EnumMember(Value = ":black_joker:")]
        BlackJoker,
        [EnumMember(Value = ":black_medium_small_square:")]
        BlackMediumSmallSquare,
        [EnumMember(Value = ":black_medium_square:")]
        BlackMediumSquare,
        [EnumMember(Value = ":black_nib:")]
        BlackNib,
        [EnumMember(Value = ":black_small_square:")]
        BlackSmallSquare,
        [EnumMember(Value = ":black_square:")]
        BlackSquare,
        [EnumMember(Value = ":black_square_button:")]
        BlackSquareButton,
        [EnumMember(Value = ":blossom:")]
        Blossom,
        [EnumMember(Value = ":blowfish:")]
        Blowfish,
        [EnumMember(Value = ":blue_book:")]
        BlueBook,
        [EnumMember(Value = ":blue_car:")]
        BlueCar,
        [EnumMember(Value = ":blue_heart:")]
        BlueHeart,
        [EnumMember(Value = ":blush:")]
        Blush,
        [EnumMember(Value = ":boar:")]
        Boar,
        [EnumMember(Value = ":boat:")]
        Boat,
        [EnumMember(Value = ":bomb:")]
        Bomb,
        [EnumMember(Value = ":book:")]
        Book,
        [EnumMember(Value = ":bookmark:")]
        Bookmark,
        [EnumMember(Value = ":bookmark_tabs:")]
        BookmarkTabs,
        [EnumMember(Value = ":books:")]
        Books,
        [EnumMember(Value = ":boom:")]
        Boom,
        [EnumMember(Value = ":boot:")]
        Boot,
        [EnumMember(Value = ":bouquet:")]
        Bouquet,
        [EnumMember(Value = ":bow:")]
        Bow,
        [EnumMember(Value = ":bowling:")]
        Bowling,
        [EnumMember(Value = ":bowtie:")]
        Bowtie,
        [EnumMember(Value = ":boy:")]
        Boy,
        [EnumMember(Value = ":bread:")]
        Bread,
        [EnumMember(Value = ":bride_with_veil:")]
        BrideWithVeil,
        [EnumMember(Value = ":bridge_at_night:")]
        BridgeAtNight,
        [EnumMember(Value = ":briefcase:")]
        Briefcase,
        [EnumMember(Value = ":broken_heart:")]
        BrokenHeart,
        [EnumMember(Value = ":bug:")]
        Bug,
        [EnumMember(Value = ":bulb:")]
        Bulb,
        [EnumMember(Value = ":bullettrain_front:")]
        BullettrainFront,
        [EnumMember(Value = ":bullettrain_side:")]
        BullettrainSide,
        [EnumMember(Value = ":bus:")]
        Bus,
        [EnumMember(Value = ":busstop:")]
        Busstop,
        [EnumMember(Value = ":bust_in_silhouette:")]
        BustInSilhouette,
        [EnumMember(Value = ":busts_in_silhouette:")]
        BustsInSilhouette,
        [EnumMember(Value = ":cactus:")]
        Cactus,
        [EnumMember(Value = ":cake:")]
        Cake,
        [EnumMember(Value = ":calendar:")]
        Calendar,
        [EnumMember(Value = ":calling:")]
        Calling,
        [EnumMember(Value = ":camel:")]
        Camel,
        [EnumMember(Value = ":camera:")]
        Camera,
        [EnumMember(Value = ":cancer:")]
        Cancer,
        [EnumMember(Value = ":candy:")]
        Candy,
        [EnumMember(Value = ":capital_abcd:")]
        CapitalAbcd,
        [EnumMember(Value = ":capricorn:")]
        Capricorn,
        [EnumMember(Value = ":car:")]
        Car,
        [EnumMember(Value = ":card_index:")]
        CardIndex,
        [EnumMember(Value = ":carousel_horse:")]
        CarouselHorse,
        [EnumMember(Value = ":cat:")]
        Cat,
        [EnumMember(Value = ":cat2:")]
        Cat2,
        [EnumMember(Value = ":cd:")]
        Cd,
        [EnumMember(Value = ":chart:")]
        Chart,
        [EnumMember(Value = ":chart_with_downwards_trend:")]
        ChartWithDownwardsTrend,
        [EnumMember(Value = ":chart_with_upwards_trend:")]
        ChartWithUpwardsTrend,
        [EnumMember(Value = ":checkered_flag:")]
        CheckeredFlag,
        [EnumMember(Value = ":cherries:")]
        Cherries,
        [EnumMember(Value = ":cherry_blossom:")]
        CherryBlossom,
        [EnumMember(Value = ":chestnut:")]
        Chestnut,
        [EnumMember(Value = ":chicken:")]
        Chicken,
        [EnumMember(Value = ":children_crossing:")]
        ChildrenCrossing,
        [EnumMember(Value = ":chocolate_bar:")]
        ChocolateBar,
        [EnumMember(Value = ":christmas_tree:")]
        ChristmasTree,
        [EnumMember(Value = ":church:")]
        Church,
        [EnumMember(Value = ":cinema:")]
        Cinema,
        [EnumMember(Value = ":circus_tent:")]
        CircusTent,
        [EnumMember(Value = ":city_sunrise:")]
        CitySunrise,
        [EnumMember(Value = ":city_sunset:")]
        CitySunset,
        [EnumMember(Value = ":cl:")]
        Cl,
        [EnumMember(Value = ":clap:")]
        Clap,
        [EnumMember(Value = ":clapper:")]
        Clapper,
        [EnumMember(Value = ":clipboard:")]
        Clipboard,
        [EnumMember(Value = ":clock1:")]
        Clock1,
        [EnumMember(Value = ":clock10:")]
        Clock10,
        [EnumMember(Value = ":clock1030:")]
        Clock1030,
        [EnumMember(Value = ":clock11:")]
        Clock11,
        [EnumMember(Value = ":clock1130:")]
        Clock1130,
        [EnumMember(Value = ":clock12:")]
        Clock12,
        [EnumMember(Value = ":clock1230:")]
        Clock1230,
        [EnumMember(Value = ":clock130:")]
        Clock130,
        [EnumMember(Value = ":clock2:")]
        Clock2,
        [EnumMember(Value = ":clock230:")]
        Clock230,
        [EnumMember(Value = ":clock3:")]
        Clock3,
        [EnumMember(Value = ":clock330:")]
        Clock330,
        [EnumMember(Value = ":clock4:")]
        Clock4,
        [EnumMember(Value = ":clock430:")]
        Clock430,
        [EnumMember(Value = ":clock5:")]
        Clock5,
        [EnumMember(Value = ":clock530:")]
        Clock530,
        [EnumMember(Value = ":clock6:")]
        Clock6,
        [EnumMember(Value = ":clock630:")]
        Clock630,
        [EnumMember(Value = ":clock7:")]
        Clock7,
        [EnumMember(Value = ":clock730:")]
        Clock730,
        [EnumMember(Value = ":clock8:")]
        Clock8,
        [EnumMember(Value = ":clock830:")]
        Clock830,
        [EnumMember(Value = ":clock9:")]
        Clock9,
        [EnumMember(Value = ":clock930:")]
        Clock930,
        [EnumMember(Value = ":closed_book:")]
        ClosedBook,
        [EnumMember(Value = ":closed_lock_with_key:")]
        ClosedLockWithKey,
        [EnumMember(Value = ":closed_umbrella:")]
        ClosedUmbrella,
        [EnumMember(Value = ":cloud:")]
        Cloud,
        [EnumMember(Value = ":clubs:")]
        Clubs,
        [EnumMember(Value = ":cn:")]
        Cn,
        [EnumMember(Value = ":cocktail:")]
        Cocktail,
        [EnumMember(Value = ":coffee:")]
        Coffee,
        [EnumMember(Value = ":cold_sweat:")]
        ColdSweat,
        [EnumMember(Value = ":collision:")]
        Collision,
        [EnumMember(Value = ":computer:")]
        Computer,
        [EnumMember(Value = ":confetti_ball:")]
        ConfettiBall,
        [EnumMember(Value = ":confounded:")]
        Confounded,
        [EnumMember(Value = ":confused:")]
        Confused,
        [EnumMember(Value = ":congratulations:")]
        Congratulations,
        [EnumMember(Value = ":construction:")]
        Construction,
        [EnumMember(Value = ":construction_worker:")]
        ConstructionWorker,
        [EnumMember(Value = ":convenience_store:")]
        ConvenienceStore,
        [EnumMember(Value = ":cookie:")]
        Cookie,
        [EnumMember(Value = ":cool:")]
        Cool,
        [EnumMember(Value = ":cop:")]
        Cop,
        [EnumMember(Value = ":copyright:")]
        Copyright,
        [EnumMember(Value = ":corn:")]
        Corn,
        [EnumMember(Value = ":couple:")]
        Couple,
        [EnumMember(Value = ":couple_with_heart:")]
        CoupleWithHeart,
        [EnumMember(Value = ":couplekiss:")]
        Couplekiss,
        [EnumMember(Value = ":cow:")]
        Cow,
        [EnumMember(Value = ":cow2:")]
        Cow2,
        [EnumMember(Value = ":credit_card:")]
        CreditCard,
        [EnumMember(Value = ":crocodile:")]
        Crocodile,
        [EnumMember(Value = ":crossed_flags:")]
        CrossedFlags,
        [EnumMember(Value = ":crown:")]
        Crown,
        [EnumMember(Value = ":cry:")]
        Cry,
        [EnumMember(Value = ":crying_cat_face:")]
        CryingCatFace,
        [EnumMember(Value = ":crystal_ball:")]
        CrystalBall,
        [EnumMember(Value = ":cupid:")]
        Cupid,
        [EnumMember(Value = ":curly_loop:")]
        CurlyLoop,
        [EnumMember(Value = ":currency_exchange:")]
        CurrencyExchange,
        [EnumMember(Value = ":curry:")]
        Curry,
        [EnumMember(Value = ":custard:")]
        Custard,
        [EnumMember(Value = ":customs:")]
        Customs,
        [EnumMember(Value = ":cyclone:")]
        Cyclone,
        [EnumMember(Value = ":dancer:")]
        Dancer,
        [EnumMember(Value = ":dancers:")]
        Dancers,
        [EnumMember(Value = ":dango:")]
        Dango,
        [EnumMember(Value = ":dart:")]
        Dart,
        [EnumMember(Value = ":dash:")]
        Dash,
        [EnumMember(Value = ":date:")]
        Date,
        [EnumMember(Value = ":de:")]
        De,
        [EnumMember(Value = ":deciduous_tree:")]
        DeciduousTree,
        [EnumMember(Value = ":department_store:")]
        DepartmentStore,
        [EnumMember(Value = ":diamond_shape_with_a_dot_inside:")]
        DiamondShapeWithADotInside,
        [EnumMember(Value = ":diamonds:")]
        Diamonds,
        [EnumMember(Value = ":disappointed:")]
        Disappointed,
        [EnumMember(Value = ":disappointed_relieved:")]
        DisappointedRelieved,
        [EnumMember(Value = ":dizzy:")]
        Dizzy,
        [EnumMember(Value = ":dizzy_face:")]
        DizzyFace,
        [EnumMember(Value = ":do_not_litter:")]
        DoNotLitter,
        [EnumMember(Value = ":dog:")]
        Dog,
        [EnumMember(Value = ":dog2:")]
        Dog2,
        [EnumMember(Value = ":dollar:")]
        Dollar,
        [EnumMember(Value = ":dolls:")]
        Dolls,
        [EnumMember(Value = ":dolphin:")]
        Dolphin,
        [EnumMember(Value = ":donut:")]
        Donut,
        [EnumMember(Value = ":door:")]
        Door,
        [EnumMember(Value = ":doughnut:")]
        Doughnut,
        [EnumMember(Value = ":dragon:")]
        Dragon,
        [EnumMember(Value = ":dragon_face:")]
        DragonFace,
        [EnumMember(Value = ":dress:")]
        Dress,
        [EnumMember(Value = ":dromedary_camel:")]
        DromedaryCamel,
        [EnumMember(Value = ":droplet:")]
        Droplet,
        [EnumMember(Value = ":dvd:")]
        Dvd,
        [EnumMember(Value = ":e-mail:")]
        EhyphenMail,
        [EnumMember(Value = ":ear:")]
        Ear,
        [EnumMember(Value = ":ear_of_rice:")]
        EarOfRice,
        [EnumMember(Value = ":earth_africa:")]
        EarthAfrica,
        [EnumMember(Value = ":earth_americas:")]
        EarthAmericas,
        [EnumMember(Value = ":earth_asia:")]
        EarthAsia,
        [EnumMember(Value = ":egg:")]
        Egg,
        [EnumMember(Value = ":eggplant:")]
        Eggplant,
        [EnumMember(Value = ":eight:")]
        Eight,
        [EnumMember(Value = ":eight_pointed_black_star:")]
        EightPointedBlackStar,
        [EnumMember(Value = ":eight_spoked_asterisk:")]
        EightSpokedAsterisk,
        [EnumMember(Value = ":electric_plug:")]
        ElectricPlug,
        [EnumMember(Value = ":elephant:")]
        Elephant,
        [EnumMember(Value = ":email:")]
        Email,
        [EnumMember(Value = ":end:")]
        End,
        [EnumMember(Value = ":envelope:")]
        Envelope,
        [EnumMember(Value = ":es:")]
        Es,
        [EnumMember(Value = ":euro:")]
        Euro,
        [EnumMember(Value = ":european_castle:")]
        EuropeanCastle,
        [EnumMember(Value = ":european_post_office:")]
        EuropeanPostOffice,
        [EnumMember(Value = ":evergreen_tree:")]
        EvergreenTree,
        [EnumMember(Value = ":exclamation:")]
        Exclamation,
        [EnumMember(Value = ":expressionless:")]
        Expressionless,
        [EnumMember(Value = ":eyeglasses:")]
        Eyeglasses,
        [EnumMember(Value = ":eyes:")]
        Eyes,
        [EnumMember(Value = ":facepunch:")]
        Facepunch,
        [EnumMember(Value = ":factory:")]
        Factory,
        [EnumMember(Value = ":fallen_leaf:")]
        FallenLeaf,
        [EnumMember(Value = ":family:")]
        Family,
        [EnumMember(Value = ":fast_forward:")]
        FastForward,
        [EnumMember(Value = ":fax:")]
        Fax,
        [EnumMember(Value = ":fearful:")]
        Fearful,
        [EnumMember(Value = ":feelsgood:")]
        Feelsgood,
        [EnumMember(Value = ":feet:")]
        Feet,
        [EnumMember(Value = ":ferris_wheel:")]
        FerrisWheel,
        [EnumMember(Value = ":file_folder:")]
        FileFolder,
        [EnumMember(Value = ":finnadie:")]
        Finnadie,
        [EnumMember(Value = ":fire:")]
        Fire,
        [EnumMember(Value = ":fire_engine:")]
        FireEngine,
        [EnumMember(Value = ":fireworks:")]
        Fireworks,
        [EnumMember(Value = ":first_quarter_moon:")]
        FirstQuarterMoon,
        [EnumMember(Value = ":first_quarter_moon_with_face:")]
        FirstQuarterMoonWithFace,
        [EnumMember(Value = ":fish:")]
        Fish,
        [EnumMember(Value = ":fish_cake:")]
        FishCake,
        [EnumMember(Value = ":fishing_pole_and_fish:")]
        FishingPoleAndFish,
        [EnumMember(Value = ":fist:")]
        Fist,
        [EnumMember(Value = ":five:")]
        Five,
        [EnumMember(Value = ":flags:")]
        Flags,
        [EnumMember(Value = ":flashlight:")]
        Flashlight,
        [EnumMember(Value = ":floppy_disk:")]
        FloppyDisk,
        [EnumMember(Value = ":flower_playing_cards:")]
        FlowerPlayingCards,
        [EnumMember(Value = ":flushed:")]
        Flushed,
        [EnumMember(Value = ":foggy:")]
        Foggy,
        [EnumMember(Value = ":football:")]
        Football,
        [EnumMember(Value = ":fork_and_knife:")]
        ForkAndKnife,
        [EnumMember(Value = ":fountain:")]
        Fountain,
        [EnumMember(Value = ":four:")]
        Four,
        [EnumMember(Value = ":four_leaf_clover:")]
        FourLeafClover,
        [EnumMember(Value = ":fr:")]
        Fr,
        [EnumMember(Value = ":free:")]
        Free,
        [EnumMember(Value = ":fried_shrimp:")]
        FriedShrimp,
        [EnumMember(Value = ":fries:")]
        Fries,
        [EnumMember(Value = ":frog:")]
        Frog,
        [EnumMember(Value = ":frowning:")]
        Frowning,
        [EnumMember(Value = ":fu:")]
        Fu,
        [EnumMember(Value = ":fuelpump:")]
        Fuelpump,
        [EnumMember(Value = ":full_moon:")]
        FullMoon,
        [EnumMember(Value = ":full_moon_with_face:")]
        FullMoonWithFace,
        [EnumMember(Value = ":game_die:")]
        GameDie,
        [EnumMember(Value = ":gb:")]
        Gb,
        [EnumMember(Value = ":gear:")]
        Gear,
        [EnumMember(Value = ":gem:")]
        Gem,
        [EnumMember(Value = ":gemini:")]
        Gemini,
        [EnumMember(Value = ":ghost:")]
        Ghost,
        [EnumMember(Value = ":gift:")]
        Gift,
        [EnumMember(Value = ":gift_heart:")]
        GiftHeart,
        [EnumMember(Value = ":girl:")]
        Girl,
        [EnumMember(Value = ":globe_with_meridians:")]
        GlobeWithMeridians,
        [EnumMember(Value = ":goat:")]
        Goat,
        [EnumMember(Value = ":goberserk:")]
        Goberserk,
        [EnumMember(Value = ":godmode:")]
        Godmode,
        [EnumMember(Value = ":golf:")]
        Golf,
        [EnumMember(Value = ":grapes:")]
        Grapes,
        [EnumMember(Value = ":green_apple:")]
        GreenApple,
        [EnumMember(Value = ":green_book:")]
        GreenBook,
        [EnumMember(Value = ":green_heart:")]
        GreenHeart,
        [EnumMember(Value = ":grey_exclamation:")]
        GreyExclamation,
        [EnumMember(Value = ":grey_question:")]
        GreyQuestion,
        [EnumMember(Value = ":grimacing:")]
        Grimacing,
        [EnumMember(Value = ":grin:")]
        Grin,
        [EnumMember(Value = ":grinning:")]
        Grinning,
        [EnumMember(Value = ":guardsman:")]
        Guardsman,
        [EnumMember(Value = ":guitar:")]
        Guitar,
        [EnumMember(Value = ":gun:")]
        Gun,
        [EnumMember(Value = ":haircut:")]
        Haircut,
        [EnumMember(Value = ":hamburger:")]
        Hamburger,
        [EnumMember(Value = ":hammer:")]
        Hammer,
        [EnumMember(Value = ":hamster:")]
        Hamster,
        [EnumMember(Value = ":hand:")]
        Hand,
        [EnumMember(Value = ":handbag:")]
        Handbag,
        [EnumMember(Value = ":hankey:")]
        Hankey,
        [EnumMember(Value = ":hash:")]
        Hash,
        [EnumMember(Value = ":hatched_chick:")]
        HatchedChick,
        [EnumMember(Value = ":hatching_chick:")]
        HatchingChick,
        [EnumMember(Value = ":headphones:")]
        Headphones,
        [EnumMember(Value = ":hear_no_evil:")]
        HearNoEvil,
        [EnumMember(Value = ":heart:")]
        Heart,
        [EnumMember(Value = ":heart_decoration:")]
        HeartDecoration,
        [EnumMember(Value = ":heart_eyes:")]
        HeartEyes,
        [EnumMember(Value = ":heart_eyes_cat:")]
        HeartEyesCat,
        [EnumMember(Value = ":heartbeat:")]
        Heartbeat,
        [EnumMember(Value = ":heartpulse:")]
        Heartpulse,
        [EnumMember(Value = ":hearts:")]
        Hearts,
        [EnumMember(Value = ":heavy_check_mark:")]
        HeavyCheckMark,
        [EnumMember(Value = ":heavy_division_sign:")]
        HeavyDivisionSign,
        [EnumMember(Value = ":heavy_dollar_sign:")]
        HeavyDollarSign,
        [EnumMember(Value = ":heavy_exclamation_mark:")]
        HeavyExclamationMark,
        [EnumMember(Value = ":heavy_minus_sign:")]
        HeavyMinusSign,
        [EnumMember(Value = ":heavy_multiplication_x:")]
        HeavyMultiplicationX,
        [EnumMember(Value = ":heavy_plus_sign:")]
        HeavyPlusSign,
        [EnumMember(Value = ":helicopter:")]
        Helicopter,
        [EnumMember(Value = ":herb:")]
        Herb,
        [EnumMember(Value = ":hibiscus:")]
        Hibiscus,
        [EnumMember(Value = ":high_brightness:")]
        HighBrightness,
        [EnumMember(Value = ":high_heel:")]
        HighHeel,
        [EnumMember(Value = ":hocho:")]
        Hocho,
        [EnumMember(Value = ":honey_pot:")]
        HoneyPot,
        [EnumMember(Value = ":honeybee:")]
        Honeybee,
        [EnumMember(Value = ":horse:")]
        Horse,
        [EnumMember(Value = ":horse_racing:")]
        HorseRacing,
        [EnumMember(Value = ":hospital:")]
        Hospital,
        [EnumMember(Value = ":hotel:")]
        Hotel,
        [EnumMember(Value = ":hotsprings:")]
        Hotsprings,
        [EnumMember(Value = ":hourglass:")]
        Hourglass,
        [EnumMember(Value = ":hourglass_flowing_sand:")]
        HourglassFlowingSand,
        [EnumMember(Value = ":house:")]
        House,
        [EnumMember(Value = ":house_with_garden:")]
        HouseWithGarden,
        [EnumMember(Value = ":hurtrealbad:")]
        Hurtrealbad,
        [EnumMember(Value = ":hushed:")]
        Hushed,
        [EnumMember(Value = ":ice_cream:")]
        Ice_Cream,
        [EnumMember(Value = ":icecream:")]
        IceCream,
        [EnumMember(Value = ":id:")]
        Id,
        [EnumMember(Value = ":ideograph_advantage:")]
        IdeographAdvantage,
        [EnumMember(Value = ":imp:")]
        Imp,
        [EnumMember(Value = ":inbox_tray:")]
        InboxTray,
        [EnumMember(Value = ":incoming_envelope:")]
        IncomingEnvelope,
        [EnumMember(Value = ":information_desk_person:")]
        InformationDeskPerson,
        [EnumMember(Value = ":information_source:")]
        InformationSource,
        [EnumMember(Value = ":innocent:")]
        Innocent,
        [EnumMember(Value = ":interrobang:")]
        Interrobang,
        [EnumMember(Value = ":iphone:")]
        Iphone,
        [EnumMember(Value = ":it:")]
        It,
        [EnumMember(Value = ":izakaya_lantern:")]
        IzakayaLantern,
        [EnumMember(Value = ":jack_o_lantern:")]
        JackOLantern,
        [EnumMember(Value = ":japan:")]
        Japan,
        [EnumMember(Value = ":japanese_castle:")]
        JapaneseCastle,
        [EnumMember(Value = ":japanese_goblin:")]
        JapaneseGoblin,
        [EnumMember(Value = ":japanese_ogre:")]
        JapaneseOgre,
        [EnumMember(Value = ":jeans:")]
        Jeans,
        [EnumMember(Value = ":joy:")]
        Joy,
        [EnumMember(Value = ":joy_cat:")]
        JoyCat,
        [EnumMember(Value = ":jp:")]
        Jp,
        [EnumMember(Value = ":key:")]
        Key,
        [EnumMember(Value = ":keycap_ten:")]
        KeycapTen,
        [EnumMember(Value = ":kimono:")]
        Kimono,
        [EnumMember(Value = ":kiss:")]
        Kiss,
        [EnumMember(Value = ":kissing:")]
        Kissing,
        [EnumMember(Value = ":kissing_cat:")]
        KissingCat,
        [EnumMember(Value = ":kissing_closed_eyes:")]
        KissingClosedEyes,
        [EnumMember(Value = ":kissing_face:")]
        KissingFace,
        [EnumMember(Value = ":kissing_heart:")]
        KissingHeart,
        [EnumMember(Value = ":kissing_smiling_eyes:")]
        KissingSmilingEyes,
        [EnumMember(Value = ":koala:")]
        Koala,
        [EnumMember(Value = ":koko:")]
        Koko,
        [EnumMember(Value = ":kr:")]
        Kr,
        [EnumMember(Value = ":large_blue_circle:")]
        LargeBlueCircle,
        [EnumMember(Value = ":large_blue_diamond:")]
        LargeBlueDiamond,
        [EnumMember(Value = ":large_orange_diamond:")]
        LargeOrangeDiamond,
        [EnumMember(Value = ":last_quarter_moon:")]
        LastQuarterMoon,
        [EnumMember(Value = ":last_quarter_moon_with_face:")]
        LastQuarterMoonWithFace,
        [EnumMember(Value = ":laughing:")]
        Laughing,
        [EnumMember(Value = ":leaves:")]
        Leaves,
        [EnumMember(Value = ":ledger:")]
        Ledger,
        [EnumMember(Value = ":left_luggage:")]
        LeftLuggage,
        [EnumMember(Value = ":left_right_arrow:")]
        LeftRightArrow,
        [EnumMember(Value = ":leftwards_arrow_with_hook:")]
        LeftwardsArrowWithHook,
        [EnumMember(Value = ":lemon:")]
        Lemon,
        [EnumMember(Value = ":leo:")]
        Leo,
        [EnumMember(Value = ":leopard:")]
        Leopard,
        [EnumMember(Value = ":libra:")]
        Libra,
        [EnumMember(Value = ":light_rail:")]
        LightRail,
        [EnumMember(Value = ":link:")]
        Link,
        [EnumMember(Value = ":lips:")]
        Lips,
        [EnumMember(Value = ":lipstick:")]
        Lipstick,
        [EnumMember(Value = ":lock:")]
        Lock,
        [EnumMember(Value = ":lock_with_ink_pen:")]
        LockWithInkPen,
        [EnumMember(Value = ":lollipop:")]
        Lollipop,
        [EnumMember(Value = ":loop:")]
        Loop,
        [EnumMember(Value = ":loudspeaker:")]
        Loudspeaker,
        [EnumMember(Value = ":love_hotel:")]
        LoveHotel,
        [EnumMember(Value = ":love_letter:")]
        LoveLetter,
        [EnumMember(Value = ":low_brightness:")]
        LowBrightness,
        [EnumMember(Value = ":m:")]
        M,
        [EnumMember(Value = ":mag:")]
        Mag,
        [EnumMember(Value = ":mag_right:")]
        MagRight,
        [EnumMember(Value = ":mahjong:")]
        Mahjong,
        [EnumMember(Value = ":mailbox:")]
        Mailbox,
        [EnumMember(Value = ":mailbox_closed:")]
        MailboxClosed,
        [EnumMember(Value = ":mailbox_with_mail:")]
        MailboxWithMail,
        [EnumMember(Value = ":mailbox_with_no_mail:")]
        MailboxWithNoMail,
        [EnumMember(Value = ":man:")]
        Man,
        [EnumMember(Value = ":man_with_gua_pi_mao:")]
        ManWithGuaPiMao,
        [EnumMember(Value = ":man_with_turban:")]
        ManWithTurban,
        [EnumMember(Value = ":mans_shoe:")]
        MansShoe,
        [EnumMember(Value = ":maple_leaf:")]
        MapleLeaf,
        [EnumMember(Value = ":mask:")]
        Mask,
        [EnumMember(Value = ":massage:")]
        Massage,
        [EnumMember(Value = ":meat_on_bone:")]
        MeatOnBone,
        [EnumMember(Value = ":mega:")]
        Mega,
        [EnumMember(Value = ":melon:")]
        Melon,
        [EnumMember(Value = ":memo:")]
        Memo,
        [EnumMember(Value = ":mens:")]
        Mens,
        [EnumMember(Value = ":metal:")]
        Metal,
        [EnumMember(Value = ":metro:")]
        Metro,
        [EnumMember(Value = ":microphone:")]
        Microphone,
        [EnumMember(Value = ":microscope:")]
        Microscope,
        [EnumMember(Value = ":milky_way:")]
        MilkyWay,
        [EnumMember(Value = ":minibus:")]
        Minibus,
        [EnumMember(Value = ":minidisc:")]
        Minidisc,
        [EnumMember(Value = ":mobile_phone_off:")]
        MobilePhoneOff,
        [EnumMember(Value = ":money_with_wings:")]
        MoneyWithWings,
        [EnumMember(Value = ":moneybag:")]
        Moneybag,
        [EnumMember(Value = ":monkey:")]
        Monkey,
        [EnumMember(Value = ":monkey_face:")]
        MonkeyFace,
        [EnumMember(Value = ":monorail:")]
        Monorail,
        [EnumMember(Value = ":moon:")]
        Moon,
        [EnumMember(Value = ":mortar_board:")]
        MortarBoard,
        [EnumMember(Value = ":mount_fuji:")]
        MountFuji,
        [EnumMember(Value = ":mountain_bicyclist:")]
        MountainBicyclist,
        [EnumMember(Value = ":mountain_cableway:")]
        MountainCableway,
        [EnumMember(Value = ":mountain_railway:")]
        MountainRailway,
        [EnumMember(Value = ":mouse:")]
        Mouse,
        [EnumMember(Value = ":mouse2:")]
        Mouse2,
        [EnumMember(Value = ":movie_camera:")]
        MovieCamera,
        [EnumMember(Value = ":moyai:")]
        Moyai,
        [EnumMember(Value = ":muscle:")]
        Muscle,
        [EnumMember(Value = ":mushroom:")]
        Mushroom,
        [EnumMember(Value = ":musical_keyboard:")]
        MusicalKeyboard,
        [EnumMember(Value = ":musical_note:")]
        MusicalNote,
        [EnumMember(Value = ":musical_score:")]
        MusicalScore,
        [EnumMember(Value = ":mute:")]
        Mute,
        [EnumMember(Value = ":nail_care:")]
        NailCare,
        [EnumMember(Value = ":name_badge:")]
        NameBadge,
        [EnumMember(Value = ":neckbeard:")]
        Neckbeard,
        [EnumMember(Value = ":necktie:")]
        Necktie,
        [EnumMember(Value = ":negative_squared_cross_mark:")]
        NegativeSquaredCrossMark,
        [EnumMember(Value = ":neutral_face:")]
        NeutralFace,
        [EnumMember(Value = ":new:")]
        New,
        [EnumMember(Value = ":new_moon:")]
        NewMoon,
        [EnumMember(Value = ":new_moon_with_face:")]
        NewMoonWithFace,
        [EnumMember(Value = ":newspaper:")]
        Newspaper,
        [EnumMember(Value = ":ng:")]
        Ng,
        [EnumMember(Value = ":nine:")]
        Nine,
        [EnumMember(Value = ":no_bell:")]
        NoBell,
        [EnumMember(Value = ":no_bicycles:")]
        NoBicycles,
        [EnumMember(Value = ":no_entry:")]
        NoEntry,
        [EnumMember(Value = ":no_entry_sign:")]
        NoEntrySign,
        [EnumMember(Value = ":no_good:")]
        NoGood,
        [EnumMember(Value = ":no_mobile_phones:")]
        NoMobilePhones,
        [EnumMember(Value = ":no_mouth:")]
        NoMouth,
        [EnumMember(Value = ":no_pedestrians:")]
        NoPedestrians,
        [EnumMember(Value = ":no_smoking:")]
        NoSmoking,
        [EnumMember(Value = ":non-potable_water:")]
        NonPotableWater,
        [EnumMember(Value = ":nose:")]
        Nose,
        [EnumMember(Value = ":notebook:")]
        Notebook,
        [EnumMember(Value = ":notebook_with_decorative_cover:")]
        NotebookWithDecorativeCover,
        [EnumMember(Value = ":notes:")]
        Notes,
        [EnumMember(Value = ":nut_and_bolt:")]
        NutAndBolt,
        [EnumMember(Value = ":o:")]
        O,
        [EnumMember(Value = ":o2:")]
        O2,
        [EnumMember(Value = ":ocean:")]
        Ocean,
        [EnumMember(Value = ":octocat:")]
        Octocat,
        [EnumMember(Value = ":octopus:")]
        Octopus,
        [EnumMember(Value = ":oden:")]
        Oden,
        [EnumMember(Value = ":office:")]
        Office,
        [EnumMember(Value = ":ok:")]
        Ok,
        [EnumMember(Value = ":ok_hand:")]
        OkHand,
        [EnumMember(Value = ":ok_woman:")]
        OkWoman,
        [EnumMember(Value = ":older_man:")]
        OlderMan,
        [EnumMember(Value = ":older_woman:")]
        OlderWoman,
        [EnumMember(Value = ":on:")]
        On,
        [EnumMember(Value = ":oncoming_automobile:")]
        OncomingAutomobile,
        [EnumMember(Value = ":oncoming_bus:")]
        OncomingBus,
        [EnumMember(Value = ":oncoming_police_car:")]
        OncomingPoliceCar,
        [EnumMember(Value = ":oncoming_taxi:")]
        OncomingTaxi,
        [EnumMember(Value = ":one:")]
        One,
        [EnumMember(Value = ":open_file_folder:")]
        OpenFileFolder,
        [EnumMember(Value = ":open_hands:")]
        OpenHands,
        [EnumMember(Value = ":open_mouth:")]
        OpenMouth,
        [EnumMember(Value = ":ophiuchus:")]
        Ophiuchus,
        [EnumMember(Value = ":orange_book:")]
        OrangeBook,
        [EnumMember(Value = ":outbox_tray:")]
        OutboxTray,
        [EnumMember(Value = ":ox:")]
        Ox,
        [EnumMember(Value = ":package:")]
        Package,
        [EnumMember(Value = ":page_facing_up:")]
        PageFacingUp,
        [EnumMember(Value = ":page_with_curl:")]
        PageWithCurl,
        [EnumMember(Value = ":pager:")]
        Pager,
        [EnumMember(Value = ":palm_tree:")]
        PalmTree,
        [EnumMember(Value = ":panda_face:")]
        PandaFace,
        [EnumMember(Value = ":paperclip:")]
        Paperclip,
        [EnumMember(Value = ":parking:")]
        Parking,
        [EnumMember(Value = ":part_alternation_mark:")]
        PartAlternationMark,
        [EnumMember(Value = ":partly_sunny:")]
        PartlySunny,
        [EnumMember(Value = ":passport_control:")]
        PassportControl,
        [EnumMember(Value = ":paw_prints:")]
        PawPrints,
        [EnumMember(Value = ":peach:")]
        Peach,
        [EnumMember(Value = ":pear:")]
        Pear,
        [EnumMember(Value = ":pencil:")]
        Pencil,
        [EnumMember(Value = ":pencil2:")]
        Pencil2,
        [EnumMember(Value = ":penguin:")]
        Penguin,
        [EnumMember(Value = ":pensive:")]
        Pensive,
        [EnumMember(Value = ":performing_arts:")]
        PerformingArts,
        [EnumMember(Value = ":persevere:")]
        Persevere,
        [EnumMember(Value = ":person_frowning:")]
        PersonFrowning,
        [EnumMember(Value = ":person_with_blond_hair:")]
        PersonWithBlondHair,
        [EnumMember(Value = ":person_with_pouting_face:")]
        PersonWithPoutingFace,
        [EnumMember(Value = ":phone:")]
        Phone,
        [EnumMember(Value = ":pig:")]
        Pig,
        [EnumMember(Value = ":pig2:")]
        Pig2,
        [EnumMember(Value = ":pig_nose:")]
        PigNose,
        [EnumMember(Value = ":pill:")]
        Pill,
        [EnumMember(Value = ":pineapple:")]
        Pineapple,
        [EnumMember(Value = ":pisces:")]
        Pisces,
        [EnumMember(Value = ":pizza:")]
        Pizza,
        [EnumMember(Value = ":plus1:")]
        Plus1,
        [EnumMember(Value = ":point_down:")]
        PointDown,
        [EnumMember(Value = ":point_left:")]
        PointLeft,
        [EnumMember(Value = ":point_right:")]
        PointRight,
        [EnumMember(Value = ":point_up:")]
        PointUp,
        [EnumMember(Value = ":point_up_2:")]
        PointUp2,
        [EnumMember(Value = ":police_car:")]
        PoliceCar,
        [EnumMember(Value = ":poodle:")]
        Poodle,
        [EnumMember(Value = ":poop:")]
        Poop,
        [EnumMember(Value = ":post_office:")]
        PostOffice,
        [EnumMember(Value = ":postal_horn:")]
        PostalHorn,
        [EnumMember(Value = ":postbox:")]
        Postbox,
        [EnumMember(Value = ":potable_water:")]
        PotableWater,
        [EnumMember(Value = ":pouch:")]
        Pouch,
        [EnumMember(Value = ":poultry_leg:")]
        PoultryLeg,
        [EnumMember(Value = ":pound:")]
        Pound,
        [EnumMember(Value = ":pouting_cat:")]
        PoutingCat,
        [EnumMember(Value = ":pray:")]
        Pray,
        [EnumMember(Value = ":princess:")]
        Princess,
        [EnumMember(Value = ":punch:")]
        Punch,
        [EnumMember(Value = ":purple_heart:")]
        PurpleHeart,
        [EnumMember(Value = ":purse:")]
        Purse,
        [EnumMember(Value = ":pushpin:")]
        Pushpin,
        [EnumMember(Value = ":put_litter_in_its_place:")]
        PutLitterInItsPlace,
        [EnumMember(Value = ":question:")]
        Question,
        [EnumMember(Value = ":rabbit:")]
        Rabbit,
        [EnumMember(Value = ":rabbit2:")]
        Rabbit2,
        [EnumMember(Value = ":racehorse:")]
        Racehorse,
        [EnumMember(Value = ":radio:")]
        Radio,
        [EnumMember(Value = ":radio_button:")]
        RadioButton,
        [EnumMember(Value = ":rage:")]
        Rage,
        [EnumMember(Value = ":rage1:")]
        Rage1,
        [EnumMember(Value = ":rage2:")]
        Rage2,
        [EnumMember(Value = ":rage3:")]
        Rage3,
        [EnumMember(Value = ":rage4:")]
        Rage4,
        [EnumMember(Value = ":railway_car:")]
        RailwayCar,
        [EnumMember(Value = ":rainbow:")]
        Rainbow,
        [EnumMember(Value = ":raised_hand:")]
        RaisedHand,
        [EnumMember(Value = ":raised_hands:")]
        RaisedHands,
        [EnumMember(Value = ":raising_hand:")]
        RaisingHand,
        [EnumMember(Value = ":ram:")]
        Ram,
        [EnumMember(Value = ":ramen:")]
        Ramen,
        [EnumMember(Value = ":rat:")]
        Rat,
        [EnumMember(Value = ":recycle:")]
        Recycle,
        [EnumMember(Value = ":red_car:")]
        RedCar,
        [EnumMember(Value = ":red_circle:")]
        RedCircle,
        [EnumMember(Value = ":registered:")]
        Registered,
        [EnumMember(Value = ":relaxed:")]
        Relaxed,
        [EnumMember(Value = ":relieved:")]
        Relieved,
        [EnumMember(Value = ":repeat:")]
        Repeat,
        [EnumMember(Value = ":repeat_one:")]
        RepeatOne,
        [EnumMember(Value = ":restroom:")]
        Restroom,
        [EnumMember(Value = ":revolving_hearts:")]
        RevolvingHearts,
        [EnumMember(Value = ":rewind:")]
        Rewind,
        [EnumMember(Value = ":ribbon:")]
        Ribbon,
        [EnumMember(Value = ":rice:")]
        Rice,
        [EnumMember(Value = ":rice_ball:")]
        RiceBall,
        [EnumMember(Value = ":rice_cracker:")]
        RiceCracker,
        [EnumMember(Value = ":rice_scene:")]
        RiceScene,
        [EnumMember(Value = ":ring:")]
        Ring,
        [EnumMember(Value = ":robot_face:")]
        RobotFace,
        [EnumMember(Value = ":rocket:")]
        Rocket,
        [EnumMember(Value = ":roller_coaster:")]
        RollerCoaster,
        [EnumMember(Value = ":rooster:")]
        Rooster,
        [EnumMember(Value = ":rose:")]
        Rose,
        [EnumMember(Value = ":rotating_light:")]
        RotatingLight,
        [EnumMember(Value = ":round_pushpin:")]
        RoundPushpin,
        [EnumMember(Value = ":rowboat:")]
        Rowboat,
        [EnumMember(Value = ":ru:")]
        Ru,
        [EnumMember(Value = ":rugby_football:")]
        RugbyFootball,
        [EnumMember(Value = ":runner:")]
        Runner,
        [EnumMember(Value = ":running:")]
        Running,
        [EnumMember(Value = ":running_shirt_with_sash:")]
        RunningShirtWithSash,
        [EnumMember(Value = ":sa:")]
        Sa,
        [EnumMember(Value = ":sagittarius:")]
        Sagittarius,
        [EnumMember(Value = ":sailboat:")]
        Sailboat,
        [EnumMember(Value = ":sake:")]
        Sake,
        [EnumMember(Value = ":sandal:")]
        Sandal,
        [EnumMember(Value = ":santa:")]
        Santa,
        [EnumMember(Value = ":satellite:")]
        Satellite,
        [EnumMember(Value = ":satisfied:")]
        Satisfied,
        [EnumMember(Value = ":saxophone:")]
        Saxophone,
        [EnumMember(Value = ":school:")]
        School,
        [EnumMember(Value = ":school_satchel:")]
        SchoolSatchel,
        [EnumMember(Value = ":scissors:")]
        Scissors,
        [EnumMember(Value = ":scorpius:")]
        Scorpius,
        [EnumMember(Value = ":scream:")]
        Scream,
        [EnumMember(Value = ":scream_cat:")]
        ScreamCat,
        [EnumMember(Value = ":scroll:")]
        Scroll,
        [EnumMember(Value = ":seat:")]
        Seat,
        [EnumMember(Value = ":secret:")]
        Secret,
        [EnumMember(Value = ":see_no_evil:")]
        SeeNoEvil,
        [EnumMember(Value = ":seedling:")]
        Seedling,
        [EnumMember(Value = ":seven:")]
        Seven,
        [EnumMember(Value = ":shaved_ice:")]
        ShavedIce,
        [EnumMember(Value = ":sheep:")]
        Sheep,
        [EnumMember(Value = ":shell:")]
        Shell,
        [EnumMember(Value = ":ship:")]
        Ship,
        [EnumMember(Value = ":shipit:")]
        Shipit,
        [EnumMember(Value = ":shirt:")]
        Shirt,
        [EnumMember(Value = ":shit:")]
        Shit,
        [EnumMember(Value = ":shoe:")]
        Shoe,
        [EnumMember(Value = ":shower:")]
        Shower,
        [EnumMember(Value = ":signal_strength:")]
        SignalStrength,
        [EnumMember(Value = ":six:")]
        Six,
        [EnumMember(Value = ":six_pointed_star:")]
        SixPointedStar,
        [EnumMember(Value = ":ski:")]
        Ski,
        [EnumMember(Value = ":skull:")]
        Skull,
        [EnumMember(Value = ":sleeping:")]
        Sleeping,
        [EnumMember(Value = ":sleepy:")]
        Sleepy,
        [EnumMember(Value = ":slot_machine:")]
        SlotMachine,
        [EnumMember(Value = ":small_blue_diamond:")]
        SmallBlueDiamond,
        [EnumMember(Value = ":small_orange_diamond:")]
        SmallOrangeDiamond,
        [EnumMember(Value = ":small_red_triangle:")]
        SmallRedTriangle,
        [EnumMember(Value = ":small_red_triangle_down:")]
        SmallRedTriangleDown,
        [EnumMember(Value = ":smile:")]
        Smile,
        [EnumMember(Value = ":smile_cat:")]
        SmileCat,
        [EnumMember(Value = ":smiley:")]
        Smiley,
        [EnumMember(Value = ":smiley_cat:")]
        SmileyCat,
        [EnumMember(Value = ":smiling_imp:")]
        SmilingImp,
        [EnumMember(Value = ":smirk:")]
        Smirk,
        [EnumMember(Value = ":smirk_cat:")]
        SmirkCat,
        [EnumMember(Value = ":smoking:")]
        Smoking,
        [EnumMember(Value = ":snail:")]
        Snail,
        [EnumMember(Value = ":snake:")]
        Snake,
        [EnumMember(Value = ":snowboarder:")]
        Snowboarder,
        [EnumMember(Value = ":snowflake:")]
        Snowflake,
        [EnumMember(Value = ":snowman:")]
        Snowman,
        [EnumMember(Value = ":sob:")]
        Sob,
        [EnumMember(Value = ":soccer:")]
        Soccer,
        [EnumMember(Value = ":soon:")]
        Soon,
        [EnumMember(Value = ":sos:")]
        Sos,
        [EnumMember(Value = ":sound:")]
        Sound,
        [EnumMember(Value = ":space_invader:")]
        SpaceInvader,
        [EnumMember(Value = ":spades:")]
        Spades,
        [EnumMember(Value = ":spaghetti:")]
        Spaghetti,
        [EnumMember(Value = ":sparkle:")]
        Sparkle,
        [EnumMember(Value = ":sparkler:")]
        Sparkler,
        [EnumMember(Value = ":sparkles:")]
        Sparkles,
        [EnumMember(Value = ":sparkling_heart:")]
        SparklingHeart,
        [EnumMember(Value = ":speak_no_evil:")]
        SpeakNoEvil,
        [EnumMember(Value = ":speaker:")]
        Speaker,
        [EnumMember(Value = ":speech_balloon:")]
        SpeechBalloon,
        [EnumMember(Value = ":speedboat:")]
        Speedboat,
        [EnumMember(Value = ":squirrel:")]
        Squirrel,
        [EnumMember(Value = ":star:")]
        Star,
        [EnumMember(Value = ":star2:")]
        Star2,
        [EnumMember(Value = ":stars:")]
        Stars,
        [EnumMember(Value = ":station:")]
        Station,
        [EnumMember(Value = ":statue_of_liberty:")]
        StatueOfLiberty,
        [EnumMember(Value = ":steam_locomotive:")]
        SteamLocomotive,
        [EnumMember(Value = ":stew:")]
        Stew,
        [EnumMember(Value = ":straight_ruler:")]
        StraightRuler,
        [EnumMember(Value = ":strawberry:")]
        Strawberry,
        [EnumMember(Value = ":stuck_out_tongue:")]
        StuckOutTongue,
        [EnumMember(Value = ":stuck_out_tongue_closed_eyes:")]
        StuckOutTongueClosedEyes,
        [EnumMember(Value = ":stuck_out_tongue_winking_eye:")]
        StuckOutTongueWinkingEye,
        [EnumMember(Value = ":sun_with_face:")]
        SunWithFace,
        [EnumMember(Value = ":sunflower:")]
        Sunflower,
        [EnumMember(Value = ":sunglasses:")]
        Sunglasses,
        [EnumMember(Value = ":sunny:")]
        Sunny,
        [EnumMember(Value = ":sunrise:")]
        Sunrise,
        [EnumMember(Value = ":sunrise_over_mountains:")]
        SunriseOverMountains,
        [EnumMember(Value = ":surfer:")]
        Surfer,
        [EnumMember(Value = ":sushi:")]
        Sushi,
        [EnumMember(Value = ":suspect:")]
        Suspect,
        [EnumMember(Value = ":suspension_railway:")]
        SuspensionRailway,
        [EnumMember(Value = ":sweat:")]
        Sweat,
        [EnumMember(Value = ":sweat_drops:")]
        SweatDrops,
        [EnumMember(Value = ":sweat_smile:")]
        SweatSmile,
        [EnumMember(Value = ":sweet_potato:")]
        SweetPotato,
        [EnumMember(Value = ":swimmer:")]
        Swimmer,
        [EnumMember(Value = ":symbols:")]
        Symbols,
        [EnumMember(Value = ":syringe:")]
        Syringe,
        [EnumMember(Value = ":tada:")]
        Tada,
        [EnumMember(Value = ":tanabata_tree:")]
        TanabataTree,
        [EnumMember(Value = ":tangerine:")]
        Tangerine,
        [EnumMember(Value = ":taurus:")]
        Taurus,
        [EnumMember(Value = ":taxi:")]
        Taxi,
        [EnumMember(Value = ":tea:")]
        Tea,
        [EnumMember(Value = ":telephone:")]
        Telephone,
        [EnumMember(Value = ":telephone_receiver:")]
        TelephoneReceiver,
        [EnumMember(Value = ":telescope:")]
        Telescope,
        [EnumMember(Value = ":tennis:")]
        Tennis,
        [EnumMember(Value = ":tent:")]
        Tent,
        [EnumMember(Value = ":thought_balloon:")]
        ThoughtBalloon,
        [EnumMember(Value = ":three:")]
        Three,
        [EnumMember(Value = ":thumbsdown:")]
        Thumbsdown,
        [EnumMember(Value = ":thumbsup:")]
        Thumbsup,
        [EnumMember(Value = ":ticket:")]
        Ticket,
        [EnumMember(Value = ":tiger:")]
        Tiger,
        [EnumMember(Value = ":tiger2:")]
        Tiger2,
        [EnumMember(Value = ":tired_face:")]
        TiredFace,
        [EnumMember(Value = ":tm:")]
        Tm,
        [EnumMember(Value = ":toilet:")]
        Toilet,
        [EnumMember(Value = ":tokyo_tower:")]
        TokyoTower,
        [EnumMember(Value = ":tomato:")]
        Tomato,
        [EnumMember(Value = ":tongue:")]
        Tongue,
        [EnumMember(Value = ":top:")]
        Top,
        [EnumMember(Value = ":tophat:")]
        Tophat,
        [EnumMember(Value = ":tractor:")]
        Tractor,
        [EnumMember(Value = ":traffic_light:")]
        TrafficLight,
        [EnumMember(Value = ":train:")]
        Train,
        [EnumMember(Value = ":train2:")]
        Train2,
        [EnumMember(Value = ":tram:")]
        Tram,
        [EnumMember(Value = ":triangular_flag_on_post:")]
        TriangularFlagOnPost,
        [EnumMember(Value = ":triangular_ruler:")]
        TriangularRuler,
        [EnumMember(Value = ":trident:")]
        Trident,
        [EnumMember(Value = ":triumph:")]
        Triumph,
        [EnumMember(Value = ":trolleybus:")]
        Trolleybus,
        [EnumMember(Value = ":trollface:")]
        Trollface,
        [EnumMember(Value = ":trophy:")]
        Trophy,
        [EnumMember(Value = ":tropical_drink:")]
        TropicalDrink,
        [EnumMember(Value = ":tropical_fish:")]
        TropicalFish,
        [EnumMember(Value = ":truck:")]
        Truck,
        [EnumMember(Value = ":trumpet:")]
        Trumpet,
        [EnumMember(Value = ":tshirt:")]
        Tshirt,
        [EnumMember(Value = ":tulip:")]
        Tulip,
        [EnumMember(Value = ":turtle:")]
        Turtle,
        [EnumMember(Value = ":tv:")]
        Tv,
        [EnumMember(Value = ":twisted_rightwards_arrows:")]
        TwistedRightwardsArrows,
        [EnumMember(Value = ":two:")]
        Two,
        [EnumMember(Value = ":two_hearts:")]
        TwoHearts,
        [EnumMember(Value = ":two_men_holding_hands:")]
        TwoMenHoldingHands,
        [EnumMember(Value = ":two_women_holding_hands:")]
        TwoWomenHoldingHands,
        [EnumMember(Value = ":u5272:")]
        U5272,
        [EnumMember(Value = ":u5408:")]
        U5408,
        [EnumMember(Value = ":u55b6:")]
        U55B6,
        [EnumMember(Value = ":u6307:")]
        U6307,
        [EnumMember(Value = ":u6708:")]
        U6708,
        [EnumMember(Value = ":u6709:")]
        U6709,
        [EnumMember(Value = ":u6e80:")]
        U6E80,
        [EnumMember(Value = ":u7121:")]
        U7121,
        [EnumMember(Value = ":u7533:")]
        U7533,
        [EnumMember(Value = ":u7981:")]
        U7981,
        [EnumMember(Value = ":u7a7a:")]
        U7A7A,
        [EnumMember(Value = ":uk:")]
        Uk,
        [EnumMember(Value = ":umbrella:")]
        Umbrella,
        [EnumMember(Value = ":unamused:")]
        Unamused,
        [EnumMember(Value = ":underage:")]
        Underage,
        [EnumMember(Value = ":unlock:")]
        Unlock,
        [EnumMember(Value = ":up:")]
        Up,
        [EnumMember(Value = ":us:")]
        Us,
        [EnumMember(Value = ":v:")]
        V,
        [EnumMember(Value = ":vertical_traffic_light:")]
        VerticalTrafficLight,
        [EnumMember(Value = ":vhs:")]
        Vhs,
        [EnumMember(Value = ":vibration_mode:")]
        VibrationMode,
        [EnumMember(Value = ":video_camera:")]
        VideoCamera,
        [EnumMember(Value = ":video_game:")]
        VideoGame,
        [EnumMember(Value = ":violin:")]
        Violin,
        [EnumMember(Value = ":virgo:")]
        Virgo,
        [EnumMember(Value = ":volcano:")]
        Volcano,
        [EnumMember(Value = ":vs:")]
        Vs,
        [EnumMember(Value = ":walking:")]
        Walking,
        [EnumMember(Value = ":waning_crescent_moon:")]
        WaningCrescentMoon,
        [EnumMember(Value = ":waning_gibbous_moon:")]
        WaningGibbousMoon,
        [EnumMember(Value = ":warning:")]
        Warning,
        [EnumMember(Value = ":watch:")]
        Watch,
        [EnumMember(Value = ":water_buffalo:")]
        WaterBuffalo,
        [EnumMember(Value = ":watermelon:")]
        Watermelon,
        [EnumMember(Value = ":wave:")]
        Wave,
        [EnumMember(Value = ":wavy_dash:")]
        WavyDash,
        [EnumMember(Value = ":waxing_crescent_moon:")]
        WaxingCrescentMoon,
        [EnumMember(Value = ":waxing_gibbous_moon:")]
        WaxingGibbousMoon,
        [EnumMember(Value = ":wc:")]
        Wc,
        [EnumMember(Value = ":weary:")]
        Weary,
        [EnumMember(Value = ":wedding:")]
        Wedding,
        [EnumMember(Value = ":whale:")]
        Whale,
        [EnumMember(Value = ":whale2:")]
        Whale2,
        [EnumMember(Value = ":wheelchair:")]
        Wheelchair,
        [EnumMember(Value = ":white_check_mark:")]
        WhiteCheckMark,
        [EnumMember(Value = ":white_circle:")]
        WhiteCircle,
        [EnumMember(Value = ":white_flower:")]
        WhiteFlower,
        [EnumMember(Value = ":white_large_square:")]
        WhiteLargeSquare,
        [EnumMember(Value = ":white_medium_small_square:")]
        WhiteMediumSmallSquare,
        [EnumMember(Value = ":white_medium_square:")]
        WhiteMediumSquare,
        [EnumMember(Value = ":white_small_square:")]
        WhiteSmallSquare,
        [EnumMember(Value = ":white_square_button:")]
        WhiteSquareButton,
        [EnumMember(Value = ":wind_chime:")]
        WindChime,
        [EnumMember(Value = ":wine_glass:")]
        WineGlass,
        [EnumMember(Value = ":wink:")]
        Wink,
        [EnumMember(Value = ":wolf:")]
        Wolf,
        [EnumMember(Value = ":woman:")]
        Woman,
        [EnumMember(Value = ":womans_clothes:")]
        WomansClothes,
        [EnumMember(Value = ":womans_hat:")]
        WomansHat,
        [EnumMember(Value = ":womens:")]
        Womens,
        [EnumMember(Value = ":worried:")]
        Worried,
        [EnumMember(Value = ":wrench:")]
        Wrench,
        [EnumMember(Value = ":x:")]
        X,
        [EnumMember(Value = ":yellow_heart:")]
        YellowHeart,
        [EnumMember(Value = ":yen:")]
        Yen,
        [EnumMember(Value = ":yum:")]
        Yum,
        [EnumMember(Value = ":zap:")]
        Zap,
        [EnumMember(Value = ":zero:")]
        Zero,
        [EnumMember(Value = ":zzz:")]
        Zzz
    }
}
