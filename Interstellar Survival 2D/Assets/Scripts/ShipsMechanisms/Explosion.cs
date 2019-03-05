using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public ParticleSystem particle;


	public void EmitParticle(){
		particle.Emit(1);
		transform.SetParent(null);
		Invoke("Vanquish", 0.40f);
	}


	private void Vanquish(){
		Destroy(gameObject);
	}
}
