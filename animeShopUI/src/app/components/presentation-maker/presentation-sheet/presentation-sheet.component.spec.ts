import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PresentationSheetComponent } from './presentation-sheet.component';

describe('PresentationSheetComponent', () => {
  let component: PresentationSheetComponent;
  let fixture: ComponentFixture<PresentationSheetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PresentationSheetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PresentationSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
