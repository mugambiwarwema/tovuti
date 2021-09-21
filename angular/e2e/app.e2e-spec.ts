import { tovutiTemplatePage } from './app.po';

describe('tovuti App', function() {
  let page: tovutiTemplatePage;

  beforeEach(() => {
    page = new tovutiTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
