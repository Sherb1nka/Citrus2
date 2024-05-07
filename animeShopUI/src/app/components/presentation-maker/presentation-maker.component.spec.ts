import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PresentationMakerComponent } from './presentation-maker.component';

describe('PresentationMakerComponent', () => {
  let component: PresentationMakerComponent;
  let fixture: ComponentFixture<PresentationMakerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PresentationMakerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PresentationMakerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
