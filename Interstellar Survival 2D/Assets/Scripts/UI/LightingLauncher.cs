using UnityEngine;
using System.Collections;

public class LightingLauncher : ButtonUI {

	public Lightning lighting;
	
	// TODO: Sound and images from divisible particles.
	// TODO: Review the thunder.

	protected override void OnClick(){
		if(Controller.over || Controller.Burnt) return;

		if(ItemsCount.IT.ConsumeThunder()){
			lighting.Activate();
		}
	}
}
