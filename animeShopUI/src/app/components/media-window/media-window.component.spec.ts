import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaWindowComponent } from './media-window.component';

describe('MediaWindowComponent', () => {
  let component: MediaWindowComponent;
  let fixture: ComponentFixture<MediaWindowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MediaWindowComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MediaWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
