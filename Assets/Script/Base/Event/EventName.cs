//事件名字
public struct EventName
{
    
    public const string HAD_PLAYER                  = "had_player";             //是否有玩家
    public const string OPP_ON_LINE                 = "opp_on_line";            //对面机器是是否有玩家上线
    public const string STUDY_JOIN                  = "study_join";             //进入\退出学习操作界面
    public const string UPDATE_STUDY_STATE          = "update_study_state";     //更新学习状态
    public const string OPP_UPDATE_STATE            = "opp_update_state";       //对方机器更换状态:选择单机或者联机
    public const string SURE_RECEIVE                = "sure_receive";           //确认收到信息
    public const string BEGIN_GAME                  = "begin_game";             //开始游戏
    public const string MOVE_GESTURE                = "move_gesture";           //移动
    public const string Dis_For                     = "dis_for";                //前倾
    public const string Dis_Back                    = "dif_back";               //后倾
    public const string Dis_Left                    = "dis_left";               //左倾
    public const string Dis_Right                   = "dis_right";              //右倾
    public const string Dot_FOR_RAKE                = "dot_for_rake";           //不前倾
    public const string Dot_Dis_Right               = "dot_dis_right";          //不右倾
    public const string Dot_Dis_Left                = "dot+dis_left";           //不左倾
    public const string Speed_Up                    = "speed_up";               //加速
    public const string SKIIP_UP                    = "SkiingRightUp";          //右手滑动抬起
    public const string Keep_Down                   = "keep_down";              //蹲下
    public const string Motionless                  = "monionless";             //静止
    public const string Update_Score                = "updateScore";            //更新分数
    public const string POP_TIP_STRING              = "pop_tip_string";         //右提示框
    public const string POP_TIP_CURE                = "pop_tip_cure";           //弯道提示
    public const string NOR_FLY_TIPWORD             = "nor_fly_tipword";        //飘字提示
    public const string Opp_Is_Playing              = "opp_is_playing";         //对方正在游戏中
    public const string Opp_Up_Gesture              = "opp_up_gestrue";         //更新对方手势
    public const string Opp_Color_Index             = "opp_color_index";        //更新对方衣服颜色
    public const string UP_OPP_TRANS                = "up_opp_trans";           //更新对方Transform
    public const string ELUDE                       = "elude";                  //越过障碍物
    //
    public const string ADD_ACCESS_COM              = "add_access_com";          //新增Access组件
    //界面开、关
    public const string OPEN_DIALOG                 = "open_dialog";
    public const string CLOSE_DIALOG                = "close_dialog";
    public const string OPEN_HOUSEBOX               = "open_housebox";
}