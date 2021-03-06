//-----------------------------------------------------------------------
//  Author: Shaun Webb
//  University: Sheffield Hallam University
//  Website: shaunwebb.co.uk
//  Github: TehWebby
//  
//  Zumo Robot code
//-----------------------------------------------------------------------
#include <ZumoMotors.h>
#define LED_PIN 13

ZumoMotors motors;
int str;
int speed = 0;
int limit = 400;
  
void setup(){  
  Serial.begin(9600);
  pinMode(LED_PIN, OUTPUT);
  Serial.setTimeout(100);
  digitalWrite(LED_PIN, LOW); 
}

void loop(){
  if (Serial.available()){ 
    str = Serial.parseInt(); 

    //used a custom timer when coding to increase performance
    unsigned long start = micros();
    
    //ensure the direction entered is valid
    if (isValid(str))            
      setMotors(str);
    
    resetValues();

    //used a custom timer when coding to increase performance
    unsigned long end = micros();
    unsigned long delta = end - start;
    Serial.println(delta);
  }
}

void setMotors(int dir){
  //use pointer to ref speed as we can keep the existing speed if we don't change it
  int *lSpeed = &speed;
  int *rSpeed = &speed;
  if (dir == 2)//Reverse
    setReverseSpeed();
  else if (dir == 3)//Left
    lSpeed = 0;
  else if (dir == 4)//Right
    rSpeed = 0;
  
  //loop from 0 to 400 unless reverse is active then speed=-400,limit=0
  for (speed; speed <= limit; speed++){
    motors.setSpeeds(*lSpeed, *rSpeed);
    delay(2);
  }
  //after the movement has completed, stop the motors (set speed to 0)
  stopMotors();  
}

bool isValid(int dir){
  //ensure the direction entered is valid
  if (dir > 0 && dir < 5){     
    return true;
  }
  else//maybe remove else?
    return false;
}

void setReverseSpeed(){
  //set the speed to negative if command is reverse (2)
  speed = limit*-1;
  limit = 0;
}

void resetValues(){
  speed = 0;
  limit = 400;
}

void stopMotors(){
  motors.setSpeeds(0,0);
}

