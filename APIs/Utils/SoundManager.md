 *SoundManager
 *@Brief  负责管理游戏的音频
 *@Author YYF
 *@Time   16.12.23
 *@API
 GetInstance
     *@Brief 获取一个SoundManager实例 
     *@Return SoundManager
	 
 PlayBackGroundMusic
     *@Brief 播放背景音乐 
     *@Param1 clip 该播放的clip音频
     *@Param2 loop 是否循环,默认循环 
	 
 PlaySoundEffect
     *@Brief 播放音效 
     *@Param1 clip 该播放的clip音频
     *@Param2 loop 是否循环,默认不循环 
	
 StopBackGroundMusic
     *@Brief 停止播放背景音乐 
 
 StopSoundEffect
     *@Brief 停止播放音效 
	 
 SetBackGroundMusicVolume
     *@Brief 设置背景音乐音量 
     *@Param float volume 音量大小,范围0-1.0 
 
 SetSoundEffectVolume
     *@Brief 设置背景音乐音量 
     *@Param float 音量大小,范围0-1.0 

 PauseBackGroundMusic
     *@Brief 停止播放音乐
 
 PauseSoundEffect
     *@Brief 停止播放音效 

 ResumeBackGroundMusic
     *@Brief 恢复播放音乐 

 ResumeSoundEffect
     *@Brief 恢复播放音效 	 
     
