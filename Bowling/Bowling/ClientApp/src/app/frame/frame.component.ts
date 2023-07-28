import { Component, Input } from '@angular/core';
import { FrameInfo } from '../models/frame-info'

@Component({
  selector: 'app-frame',
  templateUrl: './frame.component.html',
  styleUrls: ['./frame.component.css']
})
export class FrameComponent {
  @Input() frame: FrameInfo = new FrameInfo();
}
