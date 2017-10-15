using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;  

public class LoadText : MonoBehaviour {
	public List<string> tinkerDialogue = new List<string>();
	public List<string> monkDialogue = new List<string>();
	public List<string> badgerDialogue = new List<string>();
	public List<string> npcDialogue = new List<string>();
	public List<string> narration = new List<string>();
	public enum characters {tinker, monk, badger, npc, narrator};
	public enum scene {a,b};
	public float letterPause = 0.1f;
	public float sentencePause = 0.75f;
	public void Load(string fileName, characters _char){
		StreamReader theReader = new StreamReader(fileName, Encoding.Default);
		string line;		
		  do{
				line = theReader.ReadLine();                     
                 if (line != null){
					 switch(_char){
					 	case characters.tinker:
							tinkerDialogue.Add(line);
							break;
						case characters.monk:
							monkDialogue.Add(line);
							break;
						case characters.badger:
							badgerDialogue.Add(line);
							break;
						case characters.npc:
							npcDialogue.Add(line);
							break;
						case characters.narrator:
							narration.Add(line);
							break;
					 }
                 }
			
			}while (line != null);
	}	
}
