import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'custom-title',
  styleUrls: ['./my-title.component.css'],
  template: '<h1 @fallingTitle>{{title}}</h1>',
  animations: [
    trigger('fallingTitle', [
      transition(':enter',[
        style({transform: 'translateY(-20px)' }),
        animate(1000)
      ])
    ])
  ]

})
export class MyTitleComponent{

  @Input() title: string;

}
