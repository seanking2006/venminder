import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BowlingService } from '../bowling.service';
import { FrameInfo } from '../models/frame-info';
import { ScoreCard } from '../models/score-card';
import { ScoreCardFrame } from '../models/score-card-frame';

@Component({
  selector: 'app-bowling-score',
  templateUrl: './bowling-score.component.html',
  styleUrls: ['./bowling-score.component.css']
})
export class BowlingScoreComponent implements OnInit {

  validationErrors: string[] = [];
  bowlingScore: string = "";
  currentFrame: number = 1;

  gameFrames: ScoreCardFrame[] = [];

  frames: FrameInfo[] = [];
  //frameData: FrameInfo = new FrameInfo();
  //frameData2: FrameInfo = new FrameInfo();

  constructor(private http: HttpClient,
    private bowlingService: BowlingService) {

  }
  ngOnInit(): void {
    //this.frameData.scores = [1, 2, 0];
    //this.frameData.frameNumber = 1;

    //this.frameData2.scores = [5, 1, 10];
    //this.frameData2.frameNumber = 10;
    //this.frameData2.isLastFrame = true;

    this.clearBoard();

    //let frame: FrameInfo = new FrameInfo();
    //frame.frameNumber = 1;
    //frame.scores = [1, 2];
    //frame.isLastFrame = false;
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 2;
    //frame.scores = [3, 4];
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 3;
    //frame.scores = [3, 4];
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 4;
    //frame.scores = [3, 4];
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 5;
    //frame.scores = [3, 4];
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 6;
    //frame.scores = [3, 4];
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 7;
    //frame.scores = [3, 4];
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 8;
    //frame.scores = [3, 4];
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 9;
    //frame.scores = [3, 4];
    //this.frames.push(frame);

    //frame = new FrameInfo();
    //frame.frameNumber = 10;
    //frame.scores = [3, 4];
    //frame.isLastFrame = true;
    //frame.overallScore = "123";
    //this.frames.push(frame);


  }

  setFrameInfo(frames: any): void {

  }

  calculateScore(): void {

    this.validationErrors = [];
    let score: number = parseInt(this.bowlingScore, 10);
    if (isNaN(score)) {
      this.validationErrors.push("Please enter a number");
      return;
    }
    else if (score < 1 || score > 10) {
      this.validationErrors.push("The number should be between 1 and 10");
      return;
    }
    else {

      this.bowlingService.CalculateScore(this.bowlingScore).subscribe(data => {

        if (data.bowlWasValid) {
          this.frames = [];
          for (let i = 0; i < data.frames.length; i++) {
            let frame = new FrameInfo();
            frame.frameNumber = data.frames[i].frameNumber;
            frame.isLastFrame = i == data.frames.length - 1;
            frame.overallScore = data.frames[i].score.toString();

            frame.scores = [];
            for (let j = 0; j < data.frames[i].frameScores.length; j++) {
              frame.scores.push(data.frames[i].frameScores[j]);
            }

            this.frames.push(frame);
          }
        }
        else {
          for (let i = 0; i < data.errors.length; i++) {
            this.validationErrors.push(data.errors[i]);
          }
        }
      });
    
      
    }

    
  }

  clearBoard() {
    this.frames = [];

    let frame: FrameInfo = new FrameInfo();
    frame.frameNumber = 1;
    frame.scores = ["-", "-"];
    frame.isLastFrame = false;
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 2;
    frame.scores = ["-", "-"];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 3;
    frame.scores = ["-", "-"];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 4;
    frame.scores = ["-", "-"];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 5;
    frame.scores = ["-", "-"];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 6;
    frame.scores = ["-", "-"];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 7;
    frame.scores = ["-", "-"];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 8;
    frame.scores = ["-", "-"];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 9;
    frame.scores = ["-", "-"];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 10;
    frame.scores = ["-", "-"];  
    frame.isLastFrame = true;
    frame.overallScore = "";
    this.frames.push(frame);
  }
  resetGame(): void {
    this.validationErrors = [];
    this.clearBoard();
    this.bowlingService.ResetGame().subscribe(() => {
      console.log("Game Reset")
    });
  }
}
