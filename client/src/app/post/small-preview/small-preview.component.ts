import { Component, Input, OnInit } from '@angular/core';
import { Post } from 'src/app/_models/post';

@Component({
  selector: 'app-small-preview',
  templateUrl: './small-preview.component.html',
  styleUrls: ['./small-preview.component.css']
})
export class SmallPreviewComponent implements OnInit {
  @Input() postFromHomeComponent?: Post;
  bodyPreview?: string;
  subtitlePreview?: string;
  titlePreview?: string;

  constructor() { }

  ngOnInit(): void {
    this.bodyPreview = this.postFromHomeComponent?.paragraphs[0].substr(0, 50) + "...";
    this.subtitlePreview = this.postFromHomeComponent?.subtitle.substr(0, 25) + "...";
    this.titlePreview = this.postFromHomeComponent?.title.substr(0, 20) + "...";
  }
  
}
