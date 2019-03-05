using UnityEngine;
using System.Collections;

public class PowsManager : MonoBehaviour {

	public Player player;
	public UITextModifier powText;
	private int consecutiveKills = 0;
	private int[] cKills = {3, 6, 10, 17, 23, 30, 42};
	private int index = 0;





	private void Start(){
		ToNext();
	}


	private void ToNext(){
		if(index < cKills.Length){
			powText.ChangeFontSize(50);
			powText.ChangeText((cKills[index] - consecutiveKills).ToString());
		}
		else{
			powText.ChangeFontSize(30);
			powText.ChangeText("∞");
		}
	}



	public void EnemyDown(){
		consecutiveKills++;
		if(index < cKills.Length && consecutiveKills >= cKills[index]){
			index++;
			GrantPower(true);
			Player.notUpgraded = false;
			player.ShipsStatsChanges(true);
		}

		ToNext();
	}


	public void PlayerHit(){
		GrantPower(false);
		if(index > 0){
			index--;
			if(index-1 >= 0){
				consecutiveKills = cKills[index-1];
			}
			else{
				index = 0;
				consecutiveKills = 0;
			}
		}
		else{
			index = 0;
			consecutiveKills = 0;
			Player.notUpgraded = true;
		}
		player.ShipsStatsChanges(false);
		ToNext();
	}


	public void GrantPower(bool improve){
		switch(index){
			case 1:				// Shoots 3
				player.VaryRange(improve);
				break;
			case 2:				// Keeps shooting 3, and increases Speed
				player.VaryShootingSpeed(improve);
				break;
			case 3:				// Keeps shooting 3, but the ship moves faster
				player.VarySpeed(improve);
				break;
			case 4:				// Shoots 5
				player.VaryRange(improve);
				break;
			case 5:				// Still shoots 5 but faster
				player.VaryShootingSpeed(improve);
				break;
			case 6:				// Increases movement speed
				player.VarySpeed(improve);
				break;
			case 7:				// Increases shooting speed
				player.VaryShootingSpeed(improve);
				break;
			default:
				player.Reset();
				break;
		}
	}


	public void ShutDown(){
		powText.Disable();
	}
}
