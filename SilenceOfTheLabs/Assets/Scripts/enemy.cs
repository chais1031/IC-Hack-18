using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class enemy : MonoBehaviour {
	public float deathDistance = 0.5f;
	public float distanceAway;
	public float foundDistance;
	public Transform thisObject;
	public Transform target;
	private NavMeshAgent navComponent;
	/*random*/
	NavMeshAgent navMeshAgent;
	NavMeshPath path;
	public float timeForNewPath;
	bool inCoRoutine;
	Vector3 targetVector;
	bool validPath;

	/*Voice Recognition*/
	AudioSource aud;
	public float sensitivity = 100;
	public static float loudness = 0;

	void Start() 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		navComponent = this.gameObject.GetComponent<NavMeshAgent>();
		/*random*/
		navMeshAgent = GetComponent<NavMeshAgent>();
		path = new NavMeshPath();

		/* Record user voice */
		aud = GetComponent<AudioSource>();
		aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
		aud.loop = true;
		while(!(Microphone.GetPosition(null) > 0)) { }
		aud.Play();
	}

	void Update() 
	{
		loudness = GetAveragedVolume() * sensitivity;

		float dist = Vector3.Distance(target.position, transform.position);

		if (loudness > 35) {
			print ("you are too loud :(");
			Chase ();
		} else if (dist > foundDistance) {
			RandomWalk2 ();
		} else {
			//print("found you!!!!!!!!");

			Chase ();
		}
	}

	float GetAveragedVolume()
	{
		float[] data = new float[256];
		float a = 0;
		aud.GetOutputData(data, 0);
		foreach (float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a / 256;
	}

	void Chase()
	{
		if(target)
		{
			navComponent.SetDestination(target.position);
			//transform.LookAt (target);
		}

		else
		{
			if(target == null)
			{
				target = this.gameObject.GetComponent<Transform>();
			}
			else
			{
				target = GameObject.FindGameObjectWithTag("Player").transform;
			}
		}
		float dist = Vector3.Distance(target.position, transform.position);
		if (dist <= deathDistance)
		{
			print ("die");
		}
	}

	void RandomWalk2 () {
		Vector3 RandomDest = Random.insideUnitSphere * 18;
		NavMeshHit Hit;
		if (NavMesh.SamplePosition (RandomDest, out Hit, 10f, 1)) {
			navComponent.SetDestination (Hit.position);
		}
	}

	void RandomWalk ()
	{
		if (!inCoRoutine)
			Debug.Log ("HI");
			StartCoroutine(DoSomething());
	}

	Vector3 getNewRandomPosition ()
	{
		float x = Random.Range(-20, 20);
		float z = Random.Range(-20, 20);

		Vector3 pos = new Vector3(x, 0, z);
		return pos;
	}

	IEnumerator DoSomething ()
	{
		inCoRoutine = true;
		yield return new WaitForSeconds(timeForNewPath);
		GetNewPath();
		validPath = navMeshAgent.CalculatePath(targetVector, path);
		if (!validPath) Debug.Log("Found an invalid Path");

		while (!validPath)
		{
			yield return new WaitForSeconds(0.01f);
			GetNewPath();
			validPath = navMeshAgent.CalculatePath(targetVector, path);
		}
		inCoRoutine = false;
	}

	void GetNewPath ()
	{
		targetVector = getNewRandomPosition();
		navMeshAgent.SetDestination(targetVector);
	}
}
