/*
 * Hainan Travel Planner
 * 
 * 海南旅游规划系统
 * 行程时间：2025年11月15日 - 11月22日
 * 人数：4人
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HainanTravelPlanner
{
    /// <summary>
    /// 航班信息类
    /// </summary>
    public class FlightInfo
    {
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal PricePerPerson { get; set; }
        public decimal TotalPrice => PricePerPerson * 4;

        public override string ToString()
        {
            return $"{Airline} {FlightNumber}: {DepartureCity} -> {ArrivalCity}\n" +
                   $"出发: {DepartureTime:yyyy-MM-dd HH:mm}\n" +
                   $"到达: {ArrivalTime:yyyy-MM-dd HH:mm}\n" +
                   $"单价: ¥{PricePerPerson} | 4人总价: ¥{TotalPrice}";
        }
    }

    /// <summary>
    /// 酒店信息类
    /// </summary>
    public class HotelInfo
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public decimal PricePerNight { get; set; }
        public double Rating { get; set; }
        public string Features { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Type})\n" +
                   $"位置: {Location}\n" +
                   $"价格: ¥{PricePerNight}/晚\n" +
                   $"评分: {Rating}/5.0\n" +
                   $"特色: {Features}";
        }
    }

    /// <summary>
    /// 景点信息类
    /// </summary>
    public class Attraction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TicketPrice { get; set; }
        public string RecommendedDuration { get; set; }
        public string Tips { get; set; }

        public override string ToString()
        {
            return $"{Name}\n" +
                   $"简介: {Description}\n" +
                   $"门票: ¥{TicketPrice}/人\n" +
                   $"建议游玩时长: {RecommendedDuration}\n" +
                   $"小贴士: {Tips}";
        }
    }

    /// <summary>
    /// 美食推荐类
    /// </summary>
    public class FoodRecommendation
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string RecommendedRestaurant { get; set; }
        public decimal AveragePrice { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Category})\n" +
                   $"介绍: {Description}\n" +
                   $"推荐餐厅: {RecommendedRestaurant}\n" +
                   $"人均: ¥{AveragePrice}";
        }
    }

    /// <summary>
    /// 每日行程类
    /// </summary>
    public class DailyItinerary
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public List<string> Activities { get; set; }
        public List<string> Meals { get; set; }
        public string Accommodation { get; set; }

        public DailyItinerary()
        {
            Activities = new List<string>();
            Meals = new List<string>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"【{Date:MM月dd日}】{Title}");
            sb.AppendLine("活动安排：");
            foreach (var activity in Activities)
            {
                sb.AppendLine($"  • {activity}");
            }
            sb.AppendLine("餐饮推荐：");
            foreach (var meal in Meals)
            {
                sb.AppendLine($"  • {meal}");
            }
            sb.AppendLine($"住宿: {Accommodation}");
            return sb.ToString();
        }
    }

    /// <summary>
    /// 海南旅游规划器主类
    /// </summary>
    public class TravelPlanner
    {
        /// <summary>
        /// 获取推荐航班信息（去程和返程）
        /// </summary>
        public List<FlightInfo> GetRecommendedFlights()
        {
            var flights = new List<FlightInfo>
            {
                // 去程航班（11月15日）
                new FlightInfo
                {
                    FlightNumber = "CZ6742",
                    Airline = "南方航空",
                    DepartureCity = "北京首都机场",
                    ArrivalCity = "海口美兰机场",
                    DepartureTime = new DateTime(2025, 11, 15, 8, 30, 0),
                    ArrivalTime = new DateTime(2025, 11, 15, 12, 40, 0),
                    PricePerPerson = 680
                },
                new FlightInfo
                {
                    FlightNumber = "HU7181",
                    Airline = "海南航空",
                    DepartureCity = "上海浦东机场",
                    ArrivalCity = "三亚凤凰机场",
                    DepartureTime = new DateTime(2025, 11, 15, 7, 20, 0),
                    ArrivalTime = new DateTime(2025, 11, 15, 11, 10, 0),
                    PricePerPerson = 720
                },
                new FlightInfo
                {
                    FlightNumber = "CA1351",
                    Airline = "国航",
                    DepartureCity = "广州白云机场",
                    ArrivalCity = "三亚凤凰机场",
                    DepartureTime = new DateTime(2025, 11, 15, 9, 10, 0),
                    ArrivalTime = new DateTime(2025, 11, 15, 10, 45, 0),
                    PricePerPerson = 550
                },
                
                // 返程航班（11月22日）
                new FlightInfo
                {
                    FlightNumber = "CZ6743",
                    Airline = "南方航空",
                    DepartureCity = "海口美兰机场",
                    ArrivalCity = "北京首都机场",
                    DepartureTime = new DateTime(2025, 11, 22, 13, 30, 0),
                    ArrivalTime = new DateTime(2025, 11, 22, 17, 40, 0),
                    PricePerPerson = 690
                },
                new FlightInfo
                {
                    FlightNumber = "HU7182",
                    Airline = "海南航空",
                    DepartureCity = "三亚凤凰机场",
                    ArrivalCity = "上海浦东机场",
                    DepartureTime = new DateTime(2025, 11, 22, 12, 00, 0),
                    ArrivalTime = new DateTime(2025, 11, 22, 15, 50, 0),
                    PricePerPerson = 730
                },
                new FlightInfo
                {
                    FlightNumber = "CA1352",
                    Airline = "国航",
                    DepartureCity = "三亚凤凰机场",
                    ArrivalCity = "广州白云机场",
                    DepartureTime = new DateTime(2025, 11, 22, 14, 20, 0),
                    ArrivalTime = new DateTime(2025, 11, 22, 15, 55, 0),
                    PricePerPerson = 560
                }
            };

            return flights.OrderBy(f => f.PricePerPerson).ToList();
        }

        /// <summary>
        /// 获取性价比高的酒店推荐
        /// </summary>
        public List<HotelInfo> GetRecommendedHotels()
        {
            return new List<HotelInfo>
            {
                new HotelInfo
                {
                    Name = "三亚湾海景度假酒店",
                    Location = "三亚湾",
                    Type = "海景酒店",
                    PricePerNight = 380,
                    Rating = 4.5,
                    Features = "一线海景、免费早餐、游泳池、近椰梦长廊"
                },
                new HotelInfo
                {
                    Name = "亚龙湾温德姆度假酒店",
                    Location = "亚龙湾",
                    Type = "度假酒店",
                    PricePerNight = 580,
                    Rating = 4.7,
                    Features = "私家沙滩、热带花园、儿童乐园、spa中心"
                },
                new HotelInfo
                {
                    Name = "海棠湾喜来登度假酒店",
                    Location = "海棠湾",
                    Type = "五星度假酒店",
                    PricePerNight = 680,
                    Rating = 4.8,
                    Features = "免税店旁、无边泳池、私人海滩、多个餐厅"
                },
                new HotelInfo
                {
                    Name = "大东海银泰度假酒店",
                    Location = "大东海",
                    Type = "亲子酒店",
                    PricePerNight = 420,
                    Rating = 4.6,
                    Features = "市区便利、儿童俱乐部、海景房、餐饮丰富"
                },
                new HotelInfo
                {
                    Name = "海口观澜湖度假酒店",
                    Location = "海口观澜湖",
                    Type = "温泉度假酒店",
                    PricePerNight = 450,
                    Rating = 4.6,
                    Features = "火山岩温泉、高尔夫球场、环境清幽"
                }
            };
        }

        /// <summary>
        /// 获取主要景点推荐
        /// </summary>
        public List<Attraction> GetAttractions()
        {
            return new List<Attraction>
            {
                new Attraction
                {
                    Name = "蜈支洲岛",
                    Description = "中国马尔代夫，海水清澈见底，是潜水胜地",
                    TicketPrice = 144,
                    RecommendedDuration = "一天",
                    Tips = "建议提前网上购票，含往返船票。可体验潜水、海上项目"
                },
                new Attraction
                {
                    Name = "天涯海角",
                    Description = "海南标志性景点，巨石上刻有天涯海角字样",
                    TicketPrice = 81,
                    RecommendedDuration = "2-3小时",
                    Tips = "适合拍照留念，海边风景优美，建议下午前往看日落"
                },
                new Attraction
                {
                    Name = "亚龙湾热带天堂森林公园",
                    Description = "《非诚勿扰2》取景地，可俯瞰亚龙湾全景",
                    TicketPrice = 130,
                    RecommendedDuration = "半天",
                    Tips = "索桥、鸟巢很适合打卡，建议穿运动鞋"
                },
                new Attraction
                {
                    Name = "南山文化旅游区",
                    Description = "108米海上观音像，祈福圣地",
                    TicketPrice = 129,
                    RecommendedDuration = "半天",
                    Tips = "景区较大，可乘坐电瓶车。素斋很有特色"
                },
                new Attraction
                {
                    Name = "海棠湾免税店",
                    Description = "全球最大单体免税店，购物天堂",
                    TicketPrice = 0,
                    RecommendedDuration = "3-4小时",
                    Tips = "提前注册会员，离岛前提货。价格比专柜便宜30-50%"
                },
                new Attraction
                {
                    Name = "分界洲岛",
                    Description = "海南岛南北气候分界线，适合潜水和观海豚",
                    TicketPrice = 168,
                    RecommendedDuration = "一天",
                    Tips = "水上项目丰富，海水能见度高，适合浮潜"
                },
                new Attraction
                {
                    Name = "呀诺达热带雨林",
                    Description = "热带雨林景观，瀑布、溪流环绕",
                    TicketPrice = 170,
                    RecommendedDuration = "半天",
                    Tips = "可体验踏瀑戏水，记得带换洗衣物"
                },
                new Attraction
                {
                    Name = "骑楼老街（海口）",
                    Description = "海口历史文化街区，南洋骑楼建筑",
                    TicketPrice = 0,
                    RecommendedDuration = "2-3小时",
                    Tips = "品尝海南特色小吃，感受老海口风情"
                }
            };
        }

        /// <summary>
        /// 获取美食推荐
        /// </summary>
        public List<FoodRecommendation> GetFoodRecommendations()
        {
            return new List<FoodRecommendation>
            {
                new FoodRecommendation
                {
                    Name = "文昌鸡",
                    Category = "海南四大名菜",
                    Description = "海南最负盛名的传统名菜，皮薄肉嫩、香味甚浓",
                    RecommendedRestaurant = "润华文昌鸡店、海南老字号文昌鸡饭店",
                    AveragePrice = 60
                },
                new FoodRecommendation
                {
                    Name = "加积鸭",
                    Category = "海南四大名菜",
                    Description = "琼海嘉积镇特产，肉质肥美、骨软味香",
                    RecommendedRestaurant = "老牌嘉积鸭店",
                    AveragePrice = 65
                },
                new FoodRecommendation
                {
                    Name = "东山羊",
                    Category = "海南四大名菜",
                    Description = "万宁特产，羊肉鲜美不膻、肥而不腻",
                    RecommendedRestaurant = "东山羊专营店",
                    AveragePrice = 80
                },
                new FoodRecommendation
                {
                    Name = "和乐蟹",
                    Category = "海南四大名菜",
                    Description = "万宁和乐镇特产，膏满肉肥、味道鲜美",
                    RecommendedRestaurant = "第一市场海鲜加工店",
                    AveragePrice = 120
                },
                new FoodRecommendation
                {
                    Name = "海南粉",
                    Category = "特色小吃",
                    Description = "海南最具特色的风味小吃，米粉配多种配料",
                    RecommendedRestaurant = "海口骑楼老街各家粉店",
                    AveragePrice = 15
                },
                new FoodRecommendation
                {
                    Name = "清补凉",
                    Category = "特色甜品",
                    Description = "海南特色冰爽甜品，十多种配料营养丰富",
                    RecommendedRestaurant = "文昌邓记清补凉、海口骑楼老街",
                    AveragePrice = 12
                },
                new FoodRecommendation
                {
                    Name = "椰子鸡",
                    Category = "特色火锅",
                    Description = "以椰子水为汤底的火锅，清甜爽口",
                    RecommendedRestaurant = "四川小胡子海鲜、润园四季椰林鸡",
                    AveragePrice = 90
                },
                new FoodRecommendation
                {
                    Name = "热带水果",
                    Category = "水果",
                    Description = "芒果、椰子、菠萝蜜、山竹、莲雾等",
                    RecommendedRestaurant = "第一市场、各大超市水果区",
                    AveragePrice = 30
                },
                new FoodRecommendation
                {
                    Name = "海鲜大餐",
                    Category = "海鲜",
                    Description = "龙虾、石斑鱼、鲍鱼、海胆、扇贝等",
                    RecommendedRestaurant = "三亚第一市场、春园海鲜广场",
                    AveragePrice = 150
                }
            };
        }

        /// <summary>
        /// 生成7天详细行程规划
        /// </summary>
        public List<DailyItinerary> GetItinerary()
        {
            return new List<DailyItinerary>
            {
                new DailyItinerary
                {
                    Date = new DateTime(2025, 11, 15),
                    Title = "Day 1 - 启程出发，抵达海南",
                    Activities = new List<string>
                    {
                        "上午：搭乘航班前往海南（建议选择CA1351广州-三亚，性价比最高）",
                        "中午：抵达三亚凤凰机场，前往酒店办理入住",
                        "下午：酒店休整，适应气候",
                        "傍晚：三亚湾椰梦长廊漫步，欣赏日落",
                        "晚上：第一市场海鲜大餐"
                    },
                    Meals = new List<string>
                    {
                        "午餐：机场简餐或酒店周边",
                        "晚餐：第一市场海鲜加工（人均150元，推荐龙虾、石斑鱼、和乐蟹）"
                    },
                    Accommodation = "三亚湾海景度假酒店（¥380/晚）"
                },
                new DailyItinerary
                {
                    Date = new DateTime(2025, 11, 16),
                    Title = "Day 2 - 蜈支洲岛海岛游",
                    Activities = new List<string>
                    {
                        "早上7:30：酒店早餐后出发",
                        "上午9:00：抵达蜈支洲岛码头，乘船上岛（约20分钟）",
                        "上午-下午：岛上游玩（环岛游、潜水、海上项目）",
                        "下午16:00：返回码头，前往海棠湾",
                        "傍晚：海棠湾免税店购物（3-4小时）",
                        "晚上：返回酒店休息"
                    },
                    Meals = new List<string>
                    {
                        "午餐：岛上餐厅（建议自带零食饮料补充）",
                        "晚餐：海棠湾美食广场或酒店附近（推荐椰子鸡火锅，人均90元）"
                    },
                    Accommodation = "海棠湾喜来登度假酒店（¥680/晚，靠近免税店）"
                },
                new DailyItinerary
                {
                    Date = new DateTime(2025, 11, 17),
                    Title = "Day 3 - 亚龙湾度假",
                    Activities = new List<string>
                    {
                        "上午：亚龙湾热带天堂森林公园（鸟巢、索桥打卡）",
                        "中午：公园内或下山后用餐",
                        "下午：亚龙湾海滩自由活动（游泳、沙滩排球、日光浴）",
                        "下午：酒店享受设施（游泳池、私家沙滩）",
                        "傍晚：海边漫步，观赏日落",
                        "晚上：酒店内或周边餐厅晚餐"
                    },
                    Meals = new List<string>
                    {
                        "午餐：森林公园餐厅或亚龙湾周边",
                        "晚餐：酒店自助餐或品尝文昌鸡（老字号文昌鸡饭店，人均60元）"
                    },
                    Accommodation = "亚龙湾温德姆度假酒店（¥580/晚）"
                },
                new DailyItinerary
                {
                    Date = new DateTime(2025, 11, 18),
                    Title = "Day 4 - 南山文化之旅",
                    Activities = new List<string>
                    {
                        "上午8:00：前往南山文化旅游区",
                        "上午-中午：游览海上观音、南山寺、长寿谷",
                        "中午：品尝南山素斋",
                        "下午：天涯海角游览拍照",
                        "傍晚：天涯海角海滩看日落",
                        "晚上：返回三亚市区，春园海鲜广场晚餐"
                    },
                    Meals = new List<string>
                    {
                        "午餐：南山素斋（特色推荐，人均80元）",
                        "晚餐：春园海鲜广场（人均120元）"
                    },
                    Accommodation = "大东海银泰度假酒店（¥420/晚，市区便利）"
                },
                new DailyItinerary
                {
                    Date = new DateTime(2025, 11, 19),
                    Title = "Day 5 - 热带雨林探险",
                    Activities = new List<string>
                    {
                        "上午：呀诺达热带雨林景区",
                        "上午-中午：雨林徒步、踏瀑戏水（记得带换洗衣物）",
                        "下午：分界洲岛游玩（潜水、观海豚）",
                        "傍晚：返回酒店",
                        "晚上：酒店周边觅食"
                    },
                    Meals = new List<string>
                    {
                        "午餐：景区餐厅",
                        "晚餐：品尝加积鸭（老牌嘉积鸭店，人均65元）"
                    },
                    Accommodation = "大东海银泰度假酒店（¥420/晚）"
                },
                new DailyItinerary
                {
                    Date = new DateTime(2025, 11, 20),
                    Title = "Day 6 - 前往海口，文化体验",
                    Activities = new List<string>
                    {
                        "上午：退房，前往海口（约3小时车程）",
                        "中午：抵达海口，酒店入住",
                        "下午：骑楼老街游览（南洋建筑、特色小吃）",
                        "下午：品尝海南粉、清补凉等特色小吃",
                        "傍晚：世纪大桥、万绿园观光",
                        "晚上：海口夜市美食"
                    },
                    Meals = new List<string>
                    {
                        "午餐：骑楼老街小吃（海南粉15元、清补凉12元）",
                        "晚餐：海口海鲜或东山羊（东山羊专营店，人均80元）"
                    },
                    Accommodation = "海口观澜湖度假酒店（¥450/晚）"
                },
                new DailyItinerary
                {
                    Date = new DateTime(2025, 11, 21),
                    Title = "Day 7 - 火山口公园，温泉放松",
                    Activities = new List<string>
                    {
                        "上午：海口火山口地质公园游览",
                        "中午：附近品尝火山特色美食",
                        "下午：返回酒店，享受火山岩温泉（观澜湖温泉）",
                        "下午：酒店内休闲，准备行李",
                        "傍晚：最后采购（海南特产：椰子制品、咖啡、热带水果干）",
                        "晚上：海口市区晚餐，整理行李"
                    },
                    Meals = new List<string>
                    {
                        "午餐：火山口附近农家乐",
                        "晚餐：海口市区告别晚餐（品尝还未尝试的海南美食）"
                    },
                    Accommodation = "海口观澜湖度假酒店（¥450/晚）"
                },
                new DailyItinerary
                {
                    Date = new DateTime(2025, 11, 22),
                    Title = "Day 8 - 返程",
                    Activities = new List<string>
                    {
                        "上午：酒店早餐，退房",
                        "上午：前往美兰机场",
                        "中午：办理登机手续，提取免税店商品",
                        "下午：搭乘返程航班回家"
                    },
                    Meals = new List<string>
                    {
                        "午餐：机场或飞机上"
                    },
                    Accommodation = "温馨的家"
                }
            };
        }

        /// <summary>
        /// 计算总费用预算
        /// </summary>
        public void CalculateBudget()
        {
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("【费用预算明细】（4人总计）");
            Console.WriteLine(new string('=', 80));

            // 往返机票（取最便宜的广州线路）
            decimal flightCost = (550 + 560) * 4;
            Console.WriteLine($"\n1. 往返机票：¥{flightCost}");
            Console.WriteLine($"   去程：CA1351 广州-三亚 ¥550 × 4人 = ¥{550 * 4}");
            Console.WriteLine($"   返程：CA1352 三亚-广州 ¥560 × 4人 = ¥{560 * 4}");

            // 住宿费用（7晚）
            decimal accommodationCost = 
                380 * 1 +  // Day 1: 三亚湾
                680 * 1 +  // Day 2: 海棠湾
                580 * 1 +  // Day 3: 亚龙湾
                420 * 2 +  // Day 4-5: 大东海
                450 * 2;   // Day 6-7: 海口
            Console.WriteLine($"\n2. 住宿费用（7晚，2间房）：¥{accommodationCost * 2}");
            Console.WriteLine($"   三亚湾海景度假酒店 1晚 × 2间：¥{380 * 2}");
            Console.WriteLine($"   海棠湾喜来登 1晚 × 2间：¥{680 * 2}");
            Console.WriteLine($"   亚龙湾温德姆 1晚 × 2间：¥{580 * 2}");
            Console.WriteLine($"   大东海银泰 2晚 × 2间：¥{420 * 2 * 2}");
            Console.WriteLine($"   海口观澜湖 2晚 × 2间：¥{450 * 2 * 2}");

            // 景点门票
            decimal ticketCost = (144 + 130 + 129 + 168 + 170) * 4;
            Console.WriteLine($"\n3. 景点门票：¥{ticketCost}");
            Console.WriteLine($"   蜈支洲岛 ¥144 × 4人 = ¥{144 * 4}");
            Console.WriteLine($"   亚龙湾森林公园 ¥130 × 4人 = ¥{130 * 4}");
            Console.WriteLine($"   南山文化区 ¥129 × 4人 = ¥{129 * 4}");
            Console.WriteLine($"   分界洲岛 ¥168 × 4人 = ¥{168 * 4}");
            Console.WriteLine($"   呀诺达雨林 ¥170 × 4人 = ¥{170 * 4}");

            // 餐饮费用（按人均100元/餐，每天3餐，8天）
            decimal foodCost = 100 * 3 * 8 * 4;
            Console.WriteLine($"\n4. 餐饮费用（8天）：¥{foodCost}");
            Console.WriteLine($"   人均¥100/餐 × 3餐/天 × 8天 × 4人");

            // 交通费用（当地包车或打车）
            decimal transportCost = 500 * 8;
            Console.WriteLine($"\n5. 当地交通：¥{transportCost}");
            Console.WriteLine($"   包车/打车/租车 约¥500/天 × 8天");

            // 其他费用
            decimal otherCost = 2000;
            Console.WriteLine($"\n6. 其他费用（购物、娱乐、海上项目等）：¥{otherCost}");

            decimal totalCost = flightCost + (accommodationCost * 2) + ticketCost + foodCost + transportCost + otherCost;
            
            Console.WriteLine("\n" + new string('-', 80));
            Console.WriteLine($"总计费用：¥{totalCost}");
            Console.WriteLine($"人均费用：¥{totalCost / 4}");
            Console.WriteLine(new string('=', 80));
        }

        /// <summary>
        /// 打印完整旅游规划
        /// </summary>
        public void PrintCompletePlan()
        {
            Console.WriteLine("\n" + new string('█', 80));
            Console.WriteLine("海南8天7晚深度游 - 完整旅游规划");
            Console.WriteLine("时间：2025年11月15日 - 11月22日 | 人数：4人");
            Console.WriteLine(new string('█', 80));

            // 航班推荐
            Console.WriteLine("\n【一、推荐航班】");
            Console.WriteLine(new string('-', 80));
            var flights = GetRecommendedFlights();
            Console.WriteLine("\n▶ 最具性价比方案（广州出发）：");
            var bestOutbound = flights.First(f => f.FlightNumber == "CA1351");
            var bestReturn = flights.First(f => f.FlightNumber == "CA1352");
            Console.WriteLine($"\n去程：\n{bestOutbound}\n");
            Console.WriteLine($"返程：\n{bestReturn}\n");
            Console.WriteLine($"4人往返机票总计：¥{(bestOutbound.PricePerPerson + bestReturn.PricePerPerson) * 4}");

            // 住宿推荐
            Console.WriteLine("\n【二、住宿推荐】");
            Console.WriteLine(new string('-', 80));
            var hotels = GetRecommendedHotels();
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"\n{hotel}\n");
            }

            // 景点推荐
            Console.WriteLine("\n【三、必游景点】");
            Console.WriteLine(new string('-', 80));
            var attractions = GetAttractions();
            foreach (var attraction in attractions)
            {
                Console.WriteLine($"\n{attraction}\n");
            }

            // 美食推荐
            Console.WriteLine("\n【四、美食推荐】");
            Console.WriteLine(new string('-', 80));
            var foods = GetFoodRecommendations();
            foreach (var food in foods)
            {
                Console.WriteLine($"\n{food}\n");
            }

            // 详细行程
            Console.WriteLine("\n【五、详细行程规划】");
            Console.WriteLine(new string('-', 80));
            var itinerary = GetItinerary();
            foreach (var day in itinerary)
            {
                Console.WriteLine($"\n{day}");
            }

            // 费用预算
            CalculateBudget();

            // 旅游小贴士
            Console.WriteLine("\n【六、旅游小贴士】");
            Console.WriteLine(new string('-', 80));
            var tips = new List<string>
            {
                "1. 防晒：海南紫外线强，务必准备SPF50+防晒霜、遮阳帽、太阳镜",
                "2. 衣物：以夏装为主，带1-2件薄外套（空调房、早晚温差）",
                "3. 药品：晕车药、肠胃药、防蚊虫叮咬药",
                "4. 证件：身份证、学生证（景点优惠）、驾照（租车需要）",
                "5. 预订：提前网上预订景点门票，比现场便宜10-20%",
                "6. 海鲜：第一市场买海鲜找加工店，避开拉客黄牛",
                "7. 免税：提前注册会员，离岛前2小时提货，限额10万元/人",
                "8. 交通：可租车自驾（三亚-海口高速约3小时），或包车（约500元/天）",
                "9. 最佳时间：11月海南气候舒适，温度25-30℃，是旅游旺季",
                "10. 特产：椰子制品、海南咖啡、黄辣椒酱、热带水果干适合带回家"
            };
            foreach (var tip in tips)
            {
                Console.WriteLine($"\n{tip}");
            }

            Console.WriteLine("\n" + new string('█', 80));
            Console.WriteLine("祝您旅途愉快！Have a nice trip! 🌴🌊🥥");
            Console.WriteLine(new string('█', 80) + "\n");
        }

        /// <summary>
        /// 主程序入口
        /// </summary>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            var planner = new TravelPlanner();
            planner.PrintCompletePlan();

            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }
    }
}
