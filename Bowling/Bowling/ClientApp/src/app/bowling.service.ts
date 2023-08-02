import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ScoreCard } from './models/score-card';

@Injectable({
  providedIn: 'root'
})
export class BowlingService {

  constructor(private http: HttpClient) { }

  CalculateScore(score: string) {
    return this.http.post<ScoreCard>(`/bowlingscore/bowl?score=${score}`, 1);
  }

  ResetGame() {
    return this.http.delete('/bowlingscore/reset');
  }
}
