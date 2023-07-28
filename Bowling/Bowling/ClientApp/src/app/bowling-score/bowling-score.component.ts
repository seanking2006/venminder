import { Component, OnInit } from '@angular/core';
import { FrameInfo } from '../models/frame-info';

@Component({
  selector: 'app-bowling-score',
  templateUrl: './bowling-score.component.html',
  styleUrls: ['./bowling-score.component.css']
})
export class BowlingScoreComponent implements OnInit {

  validationErrors: string[] = [];
  bowlingScore: string = "";
  currentFrame: number = 1;

  frames: FrameInfo[] = [];
  frameData: FrameInfo = new FrameInfo();
  frameData2: FrameInfo = new FrameInfo();

  ngOnInit(): void {
    this.frameData.scores = [1, 2, 0];
    this.frameData.frameNumber = 1;

    this.frameData2.scores = [5, 1, 10];
    this.frameData2.frameNumber = 10;
    this.frameData2.isLastFrame = true;

    let frame: FrameInfo = new FrameInfo();
    frame.frameNumber = 1;
    frame.scores = [1, 2];
    frame.isLastFrame = false;
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 2;
    frame.scores = [3, 4];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 3;
    frame.scores = [3, 4];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 4;
    frame.scores = [3, 4];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 5;
    frame.scores = [3, 4];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 6;
    frame.scores = [3, 4];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 7;
    frame.scores = [3, 4];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 8;
    frame.scores = [3, 4];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 9;
    frame.scores = [3, 4];
    this.frames.push(frame);

    frame = new FrameInfo();
    frame.frameNumber = 10;
    frame.scores = [3, 4];
    frame.isLastFrame = true;
    frame.overallScore = "123";
    this.frames.push(frame);


  }

  calculateScore(): void {

    this.validationErrors = [];
    let score: number = parseInt(this.bowlingScore, 10);
    if (isNaN(score)) {
      this.validationErrors.push("Please enter a number");
    }
    else if (score < 1 || score > 10) {
      this.validationErrors.push("The number should be between 1 and 10");
    }
    else {
      console.log("Score", score);
    }
  }

  resetGame(): void {
    console.log("Reset");
    this.validationErrors = [];
  }
}
